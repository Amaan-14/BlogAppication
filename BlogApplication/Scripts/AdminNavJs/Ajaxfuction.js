
function DeleteProduct(Id) {
    $.ajax({
        url: '/Blogs/Delete',
        type: 'POST',
        data: { id: Id },
        success: function (result) {

            window.location.href = '/Blogs/Index'
        },
        error: function (error) {
            alert('Error Delete Blog.')
        }
    });

}



function DeleteCategory(CategoryId) {
    $.ajax({
        url: '/Categories/Delete',
        type: 'POST',
        data: { id: CategoryId },
        success: function (result) {

            window.location.href = '/Categories/Index'
        },
        error: function (error) {
            alert('Error Delete Category.')
        }
    });

}

function DeleteUser(Id) {
    $.ajax({
        url: '/Users/Delete',
        type: 'POST',
        data: { id: Id },
        success: function (result) {

            window.location.href = '/Users/Index'
        },
        error: function (error) {
            console.log(error)
            alert('Error Delete User.')
        }
    });

}



