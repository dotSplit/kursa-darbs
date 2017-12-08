$(document).ready(function() {
    //Show Channel Creator
    $("#creation-init-channel").click(function() {
        $("#creation-box-channel").fadeIn("fast",
            function() {
                $("#close-channel-creator").fadeIn("fast");
            });
    });

    //Close Channel Creator
    $("#close-channel-creator").click(function() {
        $("#creation-box-channel").fadeOut("fast");
        $("#close-channel-creator").fadeOut("fast");
    });

    //Show Post Creator
    $("#creation-init-post").click(function() {
        $("#creation-box-post").fadeIn("fast",
            function() {
                $("#close-post-creator").fadeIn("fast");
            });
    });

    //Comment Loader
    function loadComments(postId) {
        if (postId !== null) {
            $.ajax({
                type: "GET",
                url: "Comment/Index",
                data: { 'postId': window.CurrentPost },
                cache: false,
                success: function(data) {
                    $("#creation-box-commentlist").html(data);

                }
            });
        }
    }

    //Show Comments
    var currentViewedPost = null;
    $(".view-comments-btn").click(function(event) {
        $("#creation-box-commentlist").fadeIn("fast",
            function() {
                currentViewedPost = event.currentTarget.id;
                window.CurrentPost = currentViewedPost;
                loadComments(currentViewedPost);
                $("#closecomments-button").fadeIn("fast");
                $("#post-comment-button").fadeIn("fast");
                salvattore.rescanMediaQueries();
            });
    });

    //Hide Comments
    $("#closecomments-button").click(function() {
        $("#creation-box-commentlist").fadeOut("fast");
        $("#closecomments-button").fadeOut("fast");
        $("#post-comment-button").fadeOut("fast");
        salvattore.rescanMediaQueries();
    });

    //Hide Post Creator
    $("#close-post-creator").click(
        function(event) {
            $("#creation-box-post").fadeOut("fast");
            $("#close-post-creator").fadeOut("fast");
        });

    //Hide Comment Creator
    $("#close-comment-creator").click(function(e) {
        $("#creation-box-comment").fadeOut("fast");
        $("#close-comment-creator").fadeOut("fast");
    });

    //Post Comment
    $("#post-comment-button").click(function(event) {
        $("#creation-box-comment").fadeIn("fast",
            function() {
                if (currentViewedPost !== null) {
                    $.ajax({
                        type: "GET",
                        url: "Comment/CreateForm",
                        datatype: "json",
                        data: { 'postId': currentViewedPost },
                        cache: false,
                        success: function(data) {
                            $("#creation-box-comment").html(data);
                            salvattore.rescanMediaQueries();
                            $("#close-comment-creator").fadeIn("fast");
                        }
                    });
                }
            });
    });

    //Upvote
    $(".upvote").click(
        function(event) {
            $.ajax({
                url: "User/GrantRep",
                type: "POST",
                data: { "target": $(this).attr('data-target') },
                complete: function() {

                }
            });
        });

    //Downvote
    $(".downvote").click(
        function(event) {
            $.ajax({
                url: "User/TakeRep",
                type: "POST",
                data: { "target": $(this).attr('data-target') },
                complete: function() {

                }
            });
        });


});
