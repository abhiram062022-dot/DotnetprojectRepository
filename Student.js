$(document).ready(function () {
    $('#button').on('click', function () {
        var name = $('#Name').val().trim();
        var code = $('#Code').val().trim();
        var salary = $('#Salary').val().trim();
        var phonenumber = $('#PhoneNumber').val().trim();

        if (!name) {
            alert("Please Enter Name Field !");
            return;
        }
        if (!code) {
            alert("Please Enter Code Field !"); 
            return;
        }
        if (salary == 0 || salary == "" || salary == null) {
            alert("Please Enter Salary Field !");
            return;
        }
        if (!salary) {
            alert("Please Enter Salary Field !");
            return;
        }
        if (!phonenumber) {
            alert("Please Enter Phone Number Field !");
            return;
        }

        $('#buttonsubmit').click(); // This will trigger form submission

       
    });
    $('#buttonReset').on('click', function () {
        var name = $('#Name').val("");
        var code = $('#Code').val("");
        var salary = $('#Salary').val("");
        var phonenumber = $('#PhoneNumber').val("");

    });
   /*  $('.Delete').on('click', function () {

        var id = $(this).data("id");
        var row = $(this).closest("tr");  // store row

        Swal.fire({
            icon: 'warning',
            title: 'Are you sure?',
            text: 'This action cannot be undone.',
            showCancelButton: true,
            confirmButtonText: 'Yes',
            cancelButtonText: 'No'
        }).then((result) => {

            if (result.isConfirmed) {

                $.ajax({
                    url: '/Student/Delete',
                    type: 'POST',
                    data: { id: id },

                    success: function (response) {

                        Swal.fire({
                            icon: 'success',
                            title: 'Deleted!',
                            text: 'Record deleted successfully',
                            timer: 1500,
                            showConfirmButton: false
                        });

                        // 🔥 100% Working row remove
                        row.remove();
                    },

                    error: function () {
                        Swal.fire('Error!', 'Something went wrong.', 'error');
                    }
                });
            }
        });
    });*/

    $('.Delete').on('click', function () {
        
        var id = $(this).data("id");
        var row = $(this).closest("tr");
       
        Swal.fire({
            icon: 'warning',
            title: 'Are you sure?',
            text: 'This action cannot be undone.',
            showCancelButton: true,
            confirmButtonText: 'Yes',
            cancelButtonText: 'No'
        }).then((result) => {

            if (result.isConfirmed) {

                // Call controller with AJAX
                $.ajax({
                    url: '/Student/Delete',   // your controller action
                    type: 'POST', 
                    data: { id: id },                       // send required data
                    success: function (response) {

                        Swal.fire(
                            'Deleted!',
                            response.message || 'Record deleted successfully.',
                            'success'
                        );  
                        row.remove();
                    },
                    error: function (xhr) {

                        Swal.fire(
                            'Error!',
                            xhr.responseText || 'Something went wrong.',
                            'error'
                        );

                    }
                });

            }
        });


    })
});

