// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    class Comment {
        constructor(message, postId) {
            this.message = message; 
            this.postId = postId;
        }
    }

class Like {
    constructor(postId, userId) {
        this.postId = postId;
    }
}

const onLike = (e) => {
    e.preventDefault()
    let postId = null;
    if (!e.target.id) {
        postId = e.target.parentElement.id.split('_')[1];
    } else {
        postId = e.target.id.split('_')[1];
    }
    
    const like = new Like(postId)

    $.ajax({
        url: "/post/like",
        method: "POST",
        dataType: "json",
        data: like,
        success: function (response) {
            console.log(response)
            console.log(e.target)
            if (response.data) {
                if (response.added) {
                    e.target.classList.add('liked');
                    if (e.target.textContent) {
                        e.target.textContent = Number(e.target.textContent) + 1;
                    } else {
                        e.target.textContent = 1;
                    }
                } else if (response.removed) {
                    e.target.classList.remove('liked');
                    if (e.target.textContent) {
                        e.target.textContent = Number(e.target.textContent) - 1;
                    } else {
                        e.target.textContent = "";
                    }
                }
            }
        }
    })
    //location.href = location.href;
    console.log(postId)
}

const onSave = () => {
    $(document).ready(function () {
        const id = document.querySelector(".id").value;
        const count = document.querySelector(`#count_${id}`);
        const message = document.querySelector("#comment").value;
        

        const comment = new Comment(message, id);
        console.log(comment);

        $.ajax({
            url: "/post/postcomment",
            method: "POST",
            dataType: "json",
            data: comment,
            success: function (response) {
                if (response.success) {
                    console.log(response);

                    console.log(count);

                    count.textContent = Number(count.textContent) + 1;
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        });
    })
}

$("#saveComment").on('submit', function (event) {
    console.log(event.target)
    onReady(event);
})

function loadData(e) {
    let id = e.target.id;
    if (e.target.nodeName !== 'A') {
        id = e.target.parentElement.id;
    }
    console.log(id, 'id')
    console.log(e.target)

    $('#exampleModal').on('shown.bs.modal', function (event) {
        let modal = $(this)
        let streak = $('.streak');
        modal.find('#comment').val("");
        $('#comment').focus();
        $.ajax({
            url: "/post/getone/" + id,
            method: "GET",
            dataType: "json",
            success: function (response) {
                console.log(response)
                if (response.success) {
                    modal.find('.modal-title').text(response.data.userName);
                    modal.find('.username').text(response.data.userName)
                    modal.find('.match-tip').text(response.data.tip);
                    modal.find('.location').val(response.data.location)
                    modal.find('.thoughts').text(response.data.thoughts);
                    modal.find('.time').text(response.data.timeStamp)
                    modal.find('.id').val(response.data.id)
                }
            }
        });
    })
}

function onReady(e) {
    event.preventDefault();
    console.log(e.target.id)
    $("#exampleModal").modal('hide');
    onSave();
}

//$('#exampleModal').on('hidden.bs.modal', function (e) {
//    //$(this).find('form').trigger('reset');
//    //$(this).modal('dispose');
//    console.log("destroyed");
//})

