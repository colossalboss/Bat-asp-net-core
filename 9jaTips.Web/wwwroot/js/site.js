// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$(document).ready(function () {
    class Comment {
        constructor(message, userId, postId) {
            this.message = message;
            this.appUserId = userId;
            this.postId = postId;
        }
    }

const onSave = (id) => {
        
        const message = document.querySelector("#comment").value;
        const userId = document.querySelector("#commenterId").value;

    const comment = new Comment(message, userId, id);
    console.log(comment);
    
        $.ajax({
            url: "/post/postcomment",
            method: "POST",
            dataType: "json",
            data: comment,
            success: function (response) {
                if (response.success) {
                    console.log(response);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });
    console.log("Hi")
    }


    function loadData(e) {
        let id = e.target.id;
        $('#exampleModal').on('show.bs.modal', function (event) {
            console.log(event.target);
            var modal = $(this)
            $.ajax({
                url: "/post/getone/" + id,
                method: "GET",
                dataType: "json",
                success: function (response) {
                    if (response.success) {
                        modal.find('.modal-title').text(response.data.userName);
                        modal.find('.username').text(response.data.userName)
                        modal.find('.match-tip').text(response.data.tip);
                        modal.find('.location').val(response.data.location)
                        modal.find('.thoughts').text(response.data.thoughts);
                        modal.find('.time').text(response.data.timeStamp)
                    }
                }
            });

            //document.querySelector("#saveComment").addEventListener("submit", (event) => {
            document.querySelector("#saveBtn").addEventListener("click", (event) => {
                event.preventDefault();
                console.log(id)
                $("#exampleModal").modal('hide');
                $('#exampleModal').data('modal', null);
                onSave(id);
            });
        })
    }
//});