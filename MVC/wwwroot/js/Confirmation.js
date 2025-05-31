function ConfirmDelete(id) {
    const userConfirmed = confirm("Are You Sure You Want To Delete ?");

    if (userConfirmed) {
       
        window.location.href = `/Instructor/Delete/${id}`;
    }
}