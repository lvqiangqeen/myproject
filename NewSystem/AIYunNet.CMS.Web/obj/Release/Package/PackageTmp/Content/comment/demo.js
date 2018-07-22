/**
 * Created by an.han on 14-2-20.
 */

window.onload = function () {
    var list = document.getElementById('list');
    //window.boxs = $("#list").children("div");
    
    var timer;
    bindonclick();
    //格式化日期
    function formateDate(date) {
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        var h = date.getHours();
        var mi = date.getMinutes();
        m = m > 9 ? m : '0' + m;
        return y + '-' + m + '-' + d + ' ' + h + ':' + mi;
    }

    //删除节点
    function removeNode(node) {
        node.parentNode.removeChild(node);
    }

    /**
     * 赞分享
     * @param box 每个分享的div容器
     * @param el 点击的元素
     */
    function praiseBox(box, el) {
        var txt = el.innerHTML;
        var praisesTotal = box.getElementsByClassName('praises-total')[0];
        var oldTotal = parseInt(praisesTotal.getAttribute('total'));
        var newTotal;
        //if (txt == '赞') {
        //    newTotal = oldTotal + 1;
        //    praisesTotal.setAttribute('total', newTotal);
        //    praisesTotal.innerHTML = (newTotal == 1) ? '我觉得很赞' : '我和' + oldTotal + '个人觉得很赞';
        //    el.innerHTML = '取消赞';
        //}
        //else {
        //    newTotal = oldTotal - 1;
        //    praisesTotal.setAttribute('total', newTotal);
        //    praisesTotal.innerHTML = (newTotal == 0) ? '' : newTotal + '个人觉得很赞';
        //    el.innerHTML = '赞';
        //}
        //newTotal = oldTotal + 1;
        //praisesTotal.setAttribute('total', newTotal);
        //praisesTotal.innerHTML = oldTotal + '个人觉得很赞';

        //praisesTotal.style.display = (newTotal == 0) ? 'none' : 'block';

        var id = $(el).next("input").val();
        //修改数据库的赞
        $.ajax({
            async: false,
            type: "post",
            url: "../Handler/ZanAndSelectAjax.ashx",
            data: {
                DBCode: "Z_Comment",
                DBId: id,
                IdName: "comment_guid",
                methodname: "ZanClick"
            },
            success: function (data) {
                if (data) {
                    var datajson = eval('(' + data + ')');
                    if (datajson.statu == "1") {
                        newTotal = oldTotal + 1;
                        praisesTotal.setAttribute('total', newTotal);
                        praisesTotal.innerHTML = newTotal + '个人觉得很赞';
                        praisesTotal.style.display = (newTotal == 0) ? 'none' : 'block';
                    } else { alert("您今天已经为此评论点过赞。"); }

                } else {

                }
            },
            error: function (xhr, type) {
                alert('Ajax error!');
            }
        });

    }

    /**
     * 发评论
     * @param box 每个分享的div容器
     * @param el 点击的元素
     */
    var to_account, to_uname, to_uid_type;
    function reply(box, el) {
        var commentList = box.getElementsByClassName('comment-list')[0];
        var textarea = box.getElementsByClassName('comment')[0];
        var commentBox = document.createElement('div');
        commentBox.className = 'comment-box clearfix';
        commentBox.setAttribute('user', 'self');

        var utlthum = $("#urlthum").val();
        var comment_Guid = $(el).next("input").val();
        var from_account = $("#UserAccount").val();
        if (from_account == null || from_account == "") {
            alert("请重新登陆");
        } else {
            $.ajax({
                async: false,
                type: "post",
                url: "/Comment/_ReComment",
                data: {
                    from_uname: $("#UserNickName").val(),
                    from_account: $("#UserAccount").val(),
                    from_uid_type: $("#UserType").val(),
                    to_uname: to_uname,
                    to_account: to_account,
                    to_uid_type: to_uid_type,
                    comment_Guid: comment_Guid,
                    content: textarea.value
                },
                success: function (data) {
                    if (data.RetCode == 1) {

                        commentBox.innerHTML =
    '<img class="myhead" src="' + utlthum + data.Z_replyComment.thum + '" alt="" style="border-radius:50%; overflow:hidden;"/>' +
        '<div class="comment-content">' +
        '<p class="comment-text"><span class="user">' + data.Z_replyComment.from_uname + '：</span>' + textarea.value + '</p>' +
        '<p class="comment-time">' +
        data.Z_replyComment.addtime +
        '<a href="javascript:;" class="comment-operate">删除</a>' +
        '</p>' +
        '</div>';
                        commentList.appendChild(commentBox);
                        textarea.value = '';
                        textarea.onblur();
                    }
                },
                error: function (xhr, type) {
                    alert('Ajax error!');
                }
            });
        }
        

    }

    /**
     * 赞回复
     * @param el 点击的元素
     */
    function praiseReply(el) {
        var myPraise = parseInt(el.getAttribute('my'));
        var oldTotal = parseInt(el.getAttribute('total'));
        var newTotal;
        if (myPraise == 0) {
            newTotal = oldTotal + 1;
            el.setAttribute('total', newTotal);
            el.setAttribute('my', 1);
            el.innerHTML = newTotal + ' 取消赞';
        }
        else {
            newTotal = oldTotal - 1;
            el.setAttribute('total', newTotal);
            el.setAttribute('my', 0);
            el.innerHTML = (newTotal == 0) ? '赞' : newTotal + ' 赞';
        }
        el.style.display = (newTotal == 0) ? '' : 'inline-block'
    }

    /**
     * 操作留言
     * @param el 点击的元素
     */
    function operate(el) {
        var commentBox = el.parentNode.parentNode.parentNode;
        var box = commentBox.parentNode.parentNode.parentNode;
        var txt = el.innerHTML;
        var user = commentBox.getElementsByClassName('user')[0].innerHTML;
        var textarea = box.getElementsByClassName('comment')[0];
        to_account = $(el).parent("p").find(".to_account").val();
        to_uname = $(el).parent("p").find(".to_uname").val();
        to_uid_type = $(el).parent("p").find(".to_uid_type").val();
        if (txt == '回复') {
            textarea.focus();
            textarea.value = '回复' + user;
            textarea.onkeyup();
        }
        else {
            removeNode(commentBox);
        }


    }
    function bindonclick() {
        var boxs = list.children;
        //把事件代理到每条分享div容器
        for (var i = 0; i < boxs.length; i++) {

            //点击
            boxs[i].onclick = function (e) {
                e = e || window.event;
                var el = e.srcElement;
                switch (el.className) {

                    //关闭分享
                    case 'close':
                        removeNode(el.parentNode);
                        break;

                        //赞分享
                    case 'praise':
                        praiseBox(el.parentNode.parentNode.parentNode, el);
                        break;

                        //回复按钮蓝
                    case 'btn':
                        reply(el.parentNode.parentNode.parentNode, el);
                        break

                        //回复按钮灰
                    case 'btn btn-off':
                        clearTimeout(timer);
                        break;

                        //赞留言
                    case 'comment-praise':
                        praiseReply(el);
                        break;

                        //操作留言
                    case 'comment-operate':
                        operate(el);
                        break;
                }
            }

            //评论
            var textArea = boxs[i].getElementsByClassName('comment')[0];

            //评论获取焦点
            textArea.onfocus = function () {
                this.parentNode.className = 'text-box text-box-on';
                this.value = this.value == '评论…' ? '' : this.value;
                this.onkeyup();
            }

            //评论失去焦点
            textArea.onblur = function () {
                var me = this;
                var val = me.value;
                if (val == '') {
                    timer = setTimeout(function () {
                        me.value = '评论…';
                        me.parentNode.className = 'text-box';
                    }, 200);
                }
            }

            //评论按键事件
            textArea.onkeyup = function () {
                var val = this.value;
                var len = val.length;
                var els = this.parentNode.children;
                var btn = els[1];
                var word = els[3];
                if (len <= 0 || len > 140) {
                    btn.className = 'btn btn-off';
                }
                else {
                    btn.className = 'btn';
                }
                word.innerHTML = len + '/140';
            }

        }
    }

    //$("#submit").click(function () {
    //    var commentcontent = $("#comment-message").val();
    //    var from_account = $("#from_account").val();
    //    if (commentcontent == "") {
    //        alert("请填写信息");
    //    } else {
    //        if (from_account == null || from_account == "") {
    //            alert("请重新登陆");
    //        } else {
    //            $.ajax({
    //                async: false,
    //                type: "post",
    //                url: "/Comment/_CommentCase",
    //                data: {
    //                    from_uname: $("#from_uname").val(),
    //                    from_account: from_account,
    //                    from_uid_type: $("#from_uid_type").val(),
    //                    topic_id: $("#topic_id").val(),
    //                    topic_type: "WebCase",
    //                    commentcontent: commentcontent
    //                },
    //                success: function (data) {
    //                    var html = data;
    //                    $("#list").append(data);
    //                    bindonclick();
    //                    $(".wangEditor-txt").empty();
    //                },
    //                error: function (xhr, type) {
    //                    alert('Ajax error!');
    //                }
    //            });
    //        }
    //    }

    //});

    $("#submit").click(function () {
        var commentcontent = $("#comment-message").val();
        var from_account = $("#UserAccount").val();
        if (commentcontent == "") {
            alert("请填写信息");
        } else {
            if (from_account == null || from_account == "") {
                alert("请重新登陆");
            } else {
                $.ajax({
                    async: false,
                    type: "post",
                    url: "/Comment/_CommentCase",
                    data: {
                        from_uname: $("#UserNickName").val(),
                        from_account: from_account,
                        from_uid_type: $("#UserType").val(),
                        topic_id: $("#topic_id").val(),
                        topic_type: $("#topic_type").val(),
                        commentcontent: commentcontent
                    },
                    success: function (data) {
                        var html = data;
                        $("#list").prepend(data);
                        bindonclick();
                        $(".wangEditor-txt").empty();
                        $("#comment-message").val("");
                        var getHeight = $('.blog_right').height();
                        $('.main_content').css('height', getHeight + 'px');
                    },
                    error: function (xhr, type) {
                        alert('Ajax error!');
                    }
                });
            }
        }

    });
}

