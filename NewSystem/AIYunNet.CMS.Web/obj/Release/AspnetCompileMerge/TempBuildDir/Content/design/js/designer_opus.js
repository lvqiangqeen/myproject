/*设计师主页*/
$(function(require, exports, module) {

    var province = require('province');
    require('colorbox');
    var login = require('login');
    require.async('ui',function(ui){
         new ui.switchTab({
            triggerObject: $('.designer_opus .opus_nav .cls_fication'),
            showLayer: $(''),
            className: 'cls_on'
        });
        new ui.switchTab({
            triggerObject: $('.owner_comment .comment_nav .tab_comment_title'),
            showLayer: $(''),
            className: 'com_on'
        });
    });
    // 表单验证
    if($('#User_Shen').length !== 0){
        province({
            elems : ['#User_Shen' , '#User_City'],
            placeHolders: ['省/市', '市/地区']
        });    
    }
    if($('#blogForm').length > 0){
        SJB.subZbForm.init($('#blogForm #blogBtn'),115,0,1);  
        $('#blogBtn').click(function() {   
            //百度统计函数
            try{
                _hmt && _hmt.push(['_trackEvent', 'sjsbw', 'sjsbwtj', '9_1']);
            }catch(e){

            }
        }); 
    }



//    $('body').on('click', '.uploadify-button-text', function(){
//        var to8to_uid = SJB.GLOBAL_VAR.to8to_uid;
//        if (!to8to_uid)
//        {
//            return false;
//        }
//        if (userLevel != 2 && userLevel != 4 && userLevel != 5)
//        {
//            alert('对不起，只有合作设计师才能自定义背景，合作请联系4006-808-509转8888');
//            return false;
//        }
//        $("#fileInput").uploadify('upload', '*');
//    })

    //更换主页背景
    function setHeadBg(){
        //小三角的动画效果
        $('.designer_header .change_bg').mouseover(function(){
            $(this).find('img').animate({
                width:'54px',
                height:'52px'
            });
        });
        $('.designer_header .change_bg').mouseout(function(){
            $(this).find('img').animate({
                width:'44px',
                height:'42px'
            });
        });
        var headImageClick = 1;
        $('.designer_header .change_bg').click(function(){
            if(headImageClick == 1)
            {
                $.ajax({
                    url: selfUrl,
                    type: 'POST',
                    async: true,
                    dataType: 'html',
                    data: {
                        'ajax_type' : 'headImages'
                    },
                    success: function(data) {
                        $(data).appendTo('.popup_upload_head');
                        headImageClick++;
                    }
                });
            }

//            popChangeWallPaperDialog();
            $('.popup_mask , .popup_upload_head').show();
        });
        $('.popup_upload_head .upload_btn_close').live('click',function(){
            $('.popup_mask , .popup_upload_head').hide();
        });
        //设置成功后返回提示信息
        $('.popup_upload_head .set_bg').live('click', function(){
            var myImage = $(this).prev().attr('src');
            var index = $('.popup_upload_head .set_bg').index($(this));
            if (myImage == '') return false;
            $.ajax({
                url: userInfoIdUrl,
                type: 'POST',
                dataType: 'json',
                data: {
                    setDefaultPage: 1,
                    src: myImage,
                    index: index
                },
                success: function(data)
                {
                    if (data != undefined && data.code == '1001')
                    {
                        setTimeout("window.location.reload()", 800);
                        $('.popup_upload_head').hide();
                        var str = '<div class="popup_container setbg_success">\
                                    <div class="title"><p>提示</p><em class="ico_popup_close"></em></div>\
                                    <div class="content">\
                                        <p class="tips_b"><i class="ico_right_b"></i>设置成功！</p>\
                                    </div>\
                                </div>';
                        $('body').append(str);

                    } else {
                        alert('设置失败，请稍后再试');
                    }
                    return false;
                }
            });
        });
        $('.setbg_success .ico_popup_close').live('click',function(){
            $('.popup_mask').hide();  
            $('.setbg_success').remove();
            window.location.reload();
        });

        $('.popup_upload_head .btn_upload').live('click',function(){
            var to8to_uid = SJB.GLOBAL_VAR.to8to_uid;
            //只有登录用户id和博客用户id一致才可以设置壁纸
            if (!to8to_uid) {
                document.domain = 'shejiben.com';
                SJB.popLogin.init(2, 2);
                return false;
            } else if (to8to_uid != whoid) {
                return false;
            }
            if (userLevel != 2 && userLevel != 4 && userLevel != 5)
            {
                alert('对不起，只有合作设计师才能自定义背景，合作请联系4006-808-509');
                return false;
            }
            $('.popup_upload_head').hide();
            $('.upload_img').show();
            var uploadStr = '<div class="upload_img">\
                        <div class="upload_img_head">\
                            <span class="upload_head_tlt">本地上传</span>\
                            <a href="javascript:void(0)" class="upload_head_recom">系统推荐</a>\
                            <a href="javascript:void(0)" class="upload_btn_close"></a>\
                        </div>\
                        <div class="upload_img_main">\
                            <p>选择图片(尺寸：2000px*420px，2M以内图片)</p>\
                            <input type="file" id="fileInput">\
                            <div class="img_main_box">\
                                <form method="post" class="img_main_bg">\
                                    <p class="upload_sub">\
                                        <span></span>\
                                        <label class="sub_btn_box" style="display: none">\
                                            <input type="submit" value="确定" class="upload_sub_btn"/>\
                                        </label>\
                                    </p>\
                                </form>\
                            </div>\
                            <p class="prompt">\
                                <span>温馨提示</span>\
                                <span class="prompt_con">◇ 只有合作设计师才能自定义背景，合作请联系4006-808-509。</span>\
                                <span class="prompt_con">◇ 上传的图片不能大于2M，高不小于420px，宽不小于1920px。</span>\
                                <span class="prompt_con">◇ 图片上传后需要客服审核，严禁在图片中附带广告信息</span>\
                            </p>\
                        </div>\
                    </div>';
            $('body').append(uploadStr);
            //绑定按钮触发上传事件
            $('#st_up_btn').bind('click', function() {
                var to8to_uid = SJB.GLOBAL_VAR.to8to_uid;
                if (!to8to_uid)
                {
                    return false;
                }
                if (userLevel != 2 && userLevel != 4 && userLevel != 5)
                {
                    alert('对不起，只有合作设计师才能自定义背景，合作请联系4006-808-509');
                    return false;
                }
                $("#fileInput").uploadify('upload', '*');
            });

            var max_queue = 1;
            // 绑定file框 uploadify事件
            $('#fileInput').uploadify({
                'fileTypeDesc': 'Image Files',
                'fileTypeExts': '*.jpg; *.jpeg',
                'swf': '/img/front_end/huodong/uploadify_new.swf',
                'uploader': '/api/getRelativeInfo.php?act=sign&uid=' + to8to_uid,
                'fileSizeLimit': '2MB',
                'queueSizeLimit': 1,
                'removeCompleted': false,
                'multi': true,
                'simUploadLimit': 1,
                'auto': true,
                'scriptData': {
                    'uid': to8to_uid
                },
                'onUploadStart': function(file) { // 开始上传
                    $('#st_up_btn').attr('disabled', true);
                    $('#st_up_btn').val('上传中');
                    $("#fileInput").uploadify('disable', true);
                },
                'onDialogOpen': function() {
                    this.settings.file_queue_limit = max_queue;
                    this.settings.queueSizeLimit = max_queue;
                },
                'onDialogClose': function(files) {
                    var _arr = $('.cancel');
                    if (_arr) {
                        for (var i = 0; i < _arr.length; i++) {
                            var hrefAttr = $(_arr[i]).children('a').attr('href');
                            hrefAttr = hrefAttr.replace('$', '$');
                            $(_arr[i]).children('a').attr('href', hrefAttr);
                        }
                    }
                },
                'onUploadSuccess': function(file, data, response) { // 单张上传完成
                    if (typeof data != 'undefined') {
                        data = $.parseJSON(data);
                        if (data.code == 1)
                        {
                            $('.upload_sub span').html('上传成功！');
                            $('.sub_btn_box').show();
                        } else {
                            alert(data.msg);
                            $('#st_up_btn').removeAttr('disabled');
                            $('#st_up_btn').val('开始上传');
                        }
//                        window.location.reload();
//                        return false;
                    }
                },
                'onQueueComplete': function(queueData) { // 上传队列完成
                    $('#submit').attr('disabled', false);
                    $('#competition_btn').removeAttr('disabled');
                    $("#fileInput").uploadify('disable', true);
                },
                'onUploadError': function(file, errorCode, errorMsg, errorString) { // 上传出错
                    if (errorString.toLocaleLowerCase() != 'cancelled') {
//                        alert(file.name + ' 上传失败: ' + errorString);
                        alert(file.name + ' 上传失败');
                    }
                    $('#st_up_btn').removeAttr('disabled');
                    $('#st_up_btn').val('开始上传');
                },
                'onInit': function() {
                    var upBtn = $('#fileInput .uploadify-button-text');
                    if (upBtn) {
                        upBtn.text('选择图片');
                        upBtn.css('color', '#fff');
                        $('#fileInput-button').css({
                            'background': '#dd4f50',
                            'border-radius': '5px',
                            'text-align': 'center'
                        });
                        $('#SWFUpload_0').attr('width', '160');
//                        $('#SWFUpload_0').addClass('img_main_select');
                    }

                },
                'onFallback': function() {
                    alert('请检查你的flash版本');
                },
                'onSelectError': function(file, errorCode, errorMsg) {
                    if (errorCode == '-100') {
                        this.queueData.errorMsg = '最多只能能选择一张图片';
                    }
                    if (errorCode == SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE) {
                        this.queueData.errorMsg = '最多只能能选择一张图片';
                    } else if (errorCode == SWFUpload.QUEUE_ERROR.INVALID_FILETYPE) {
                        this.queueData.errorMsg = '只支持jpeg格式的图片上传';
                    }
                }
            });
        });
        $('.upload_img .upload_btn_close').live('click',function(){
            $('.popup_mask').hide(); 
            $('.upload_img').remove();   
        });
        $('.upload_img .upload_head_recom').live('click',function(){
            $('.upload_img').remove(); 
            $('.popup_upload_head').show();
        });
    } 

    // 博文内页工具栏定位
    function setToolPosition(){
        var windowW = $(window).width();
        var contentW = 990;
        $('.img_share').css({'top':'203px','display':'block'}); 
        if((windowW - contentW)/2 > 58){
               $('.img_share').css({'left':(windowW - contentW)/2 - 58 +'px'});     
        }
        else{
            $('.img_share').css({'left':'0'});
        }
    }

    function setCommentPosition(){
        if($('#image_comment').length == 0){
            return false;
        }
        $('#toImgComment').click(function(){
            var commentTop =  $('#image_comment').offset().top;
            $(document).scrollTop(commentTop);
        });    
    }

    //预约咨询
    function reservationDesigner() {
        var yuyue  = require('yuyue');
        $('.consult_box .consult').bind('click',function(){
            var sendId = parseInt( $(this).attr('data-id') );
            yuyue.free_yuyue.init( sendId, SJB.GLOBAL_VAR.to8to_uid,'blog','blogyyzx','9_3');
        });
    }

    // 评论回复 
    function replyComment(){
        $('#image_comment .def_value').live('click',function(){
            $(this).next('#comment_input').focus();
            $(this).parents('.com_div').css('border','1px #E34C51 solid');
        });
        $('#image_comment .input_text').live('focus',function(){
            $(this).parents('.com_div').css('border','1px #E34C51 solid');
        });
        $('#image_comment .input_text').live('keyup',function(){
            var value = $(this).val();
            if(value !== '' ){
                $(this).prev('.def_value').hide();
                $(this).nextAll('input:[type="submit"]').css('background','#DD4F50');
                $(this).nextAll('input:[type="submit"]').removeAttr('disabled');
            }     
        });
        $('#image_comment .input_text').live('blur',function(){
            var value = $(this).val();
            if(value == '' ){
                $(this).prev('.def_value').show();
                $(this).nextAll('.send_comment_btn').css('background','#f79b9c');
                $(this).nextAll('.send_comment_btn').attr('disabled','disabled');
            } 
            $(this).parents('.com_div').css('border','1px #eee solid');    

        }); 
        $('.com_reply').bind('click',function(){
            var cid = $(this).attr('data-cid');
            $(this).parents('li').siblings().find('.com_div01').remove();
            if($(this).next('.com_div01').length > 0){
                $(this).next('.com_div01').remove();  
                return false; 
            }
            var str = '<div class="com_div com_div01">\
                        <label class="def_value">说点什么吧！</label>\
                        <input class="input_text" name="input_text" id="reply_337" type="text" autocomplete="off" data-cid="'+ cid +'">\
                        <input class="sub_btn send_reply_btn send_comment_btn" value="提交" type="submit">\
                    </div>';
            $(this).after(str); 
            $('.com_div01').find('.input_text').focus();
            $('.com_div01').css('border','1px #E34C51 solid');       
        });
    }

    var setMenuPosition = {
        opusTop : 0,
        commentTop : 0,
        recordTop : 0,
        aboutTop : 0,
        init : function(setting){
            var _this = this;
            _this.opusTop = setting.opusTop;
            _this.commentTop = setting.commentTop;
            _this.recordTop = setting.recordTop;
            _this.aboutTop = setting.aboutTop;
            if($('.designer_opus').length < 1 && $('.owner_comment').length < 1 && $('.deal_record').length < 1 && $('.about_he').length < 1){
                return false;
            }
            var url = window.location.href;
            if(url.indexOf('#') > -1){
                var index = url.indexOf('#');
                _this.showCase(url.charAt(index+1)-1);
            }
            _this.bindClick();
            _this.bindScroll();

        },
        bindClick : function(){
            var _this = this;
            $('.designer_navs .designer_nav_ul .designer_nav_li').click(function(){
                index = $(this).index();
                _this.showCase(index);
            });  
        },
        showCase:function(index){
            var _this = this;
            if(index == 0){
                $(document).scrollTop(_this.opusTop - 40);
            }
            else if(index == 1){
                $(document).scrollTop(_this.commentTop - 40);
            }
            else if(index == 2){
                $(document).scrollTop(_this.recordTop - 40);
            }
            else if(index == 3){
                $(document).scrollTop(_this.aboutTop - 40);
            }
            $(this).addClass('cur').siblings().removeClass('cur');
        },
        bindScroll : function(){
            var _this = this;
            var scrollTop = $(document).scrollTop();
            if(scrollTop < _this.commentTop - 40){
                $('.designer_navs .designer_nav_ul .designer_nav_li').eq(0).addClass('cur').siblings().removeClass('cur');
            }
            else if(scrollTop >= _this.commentTop - 40 && scrollTop < _this.recordTop-40){
                $('.designer_navs .designer_nav_ul .designer_nav_li').eq(1).addClass('cur').siblings().removeClass('cur');
            }
            else if(scrollTop >= _this.recordTop - 40 && scrollTop < _this.aboutTop - 40){
                $('.designer_navs .designer_nav_ul .designer_nav_li').eq(2).addClass('cur').siblings().removeClass('cur');
            }
            else if(scrollTop >= _this.aboutTop - 40){
                $('.designer_navs .designer_nav_ul .designer_nav_li').eq(3).addClass('cur').siblings().removeClass('cur');
            }
        }
    
    } 

    $(window).bind('scroll',function(){
        setMenuBar();
        setMenuPosition.bindScroll();
    });

    $(window).bind('resize',function(){
        setToolPosition();
    });

    //ajax post 请求
    function pagingAjax(url, className, val) {
        var limit = arguments[3] ? arguments[3] : '';
        $.ajax({
            type: "post",
            async: true,
            url: url,
            data: {ajax_type:val, limit:limit},
            success:function(records){
                $('.' + className).html(records);
                if(className == 'case_page')
                {
                    if(caseTypeNum > limit)
                    {
                        $('.more_opus').show();
                    }
                    if(caseTypeNum <= limit)
                    {
                        $('.more_opus').hide();
                    }
                }
                //数据加载成功后重新获取各模块的top值
                setMenuPosition.init({
                    opusTop : $('.designer_opus').length < 1 ? false : $('.designer_opus').offset().top,
                    commentTop : $('.owner_comment').length < 1 ? false : $('.owner_comment').offset().top,
                    recordTop : $('.deal_record').length < 1 ? false : $('.deal_record').offset().top,
                    aboutTop : $('.about_he').length < 1 ? false :  $('.about_he').offset().top
                });
            }
        });
        return false;
    }

    tabSwitch();
    function tabSwitch(){
        var thisHref = window.location.href;
        thisHref = thisHref.split('/');
        thisHref.pop();
        var thisHrefStr = thisHref.join('/');
        var goOpusHref = thisHrefStr + '/#1';        //设计作品
        var goOwnerHref = thisHrefStr + '/#2';       //业主评价
        var goRecordHref = thisHrefStr + '/#3';      //成交记录
        //评价选项卡（好评，中评，差评）
        $('.tab_comment_title').click(function() {  
            window.location.href = goOwnerHref;
            var credit = $(this).attr('data-type');
            pagingAjax(selfUrl, 'assess_page', credit);
            return false;
        }) 
        //业主评价分页效果
        $('body').on('click', '.assess_page .page a', function(){
            window.location.href = goOwnerHref;
            if(typeof($(this).attr('href')) == 'undefined')
            {
                return false;
            }
            var aUrl = $(this).attr('href');
            var arr = aUrl.split('?');
            var url = selfUrl + "&" + arr[1];
            var type = $('.comment_main').attr('data-type');
            pagingAjax(url, 'assess_page', type);
            return false;
        }) 

         //我作品选项卡
        $('.cls_fication').click(function() { 
            var cases = $(this).attr('data-type');
            var count = $(this).attr('data-count');
            flag = true;
            casePageNum = 2;
            caseTypeNum = count;
            if($('.about_he').length > 0){
                window.location.href = goOpusHref;
            }
            if(count == 0)
            {
                var str = '<div class="no_data"><p class="tips">该分类下暂无作品</p></div>';
                $('.opus_main').html(str);
                $('.more_opus').hide();
                setMenuPosition.init({
                    opusTop : $('.designer_opus').length < 1 ? false : $('.designer_opus').offset().top,
                    commentTop : $('.owner_comment').length < 1 ? false : $('.owner_comment').offset().top,
                    recordTop : $('.deal_record').length < 1 ? false : $('.deal_record').offset().top,
                    aboutTop : $('.about_he').length < 1 ? false :  $('.about_he').offset().top
                });
                return false;
            }

            $('.case_more').attr('data-type',cases);
            pagingAjax(selfUrl, 'case_page', cases, caseNum);
            return false;
        })

         //成交记录分页效果
        $('body').on('click', '.deal_record .page a', function(){
            window.location.href = goRecordHref;
            if(typeof($(this).attr('href')) == 'undefined')
            {
                return false;
            }
            var aUrl = $(this).attr('href');
            var arr = aUrl.split('?');
            var url = selfUrl + "&" + arr[1];
           pagingAjax(url, 'real_record_list', 'record_page');
           return false;
        });
    }
    

    
   



    /***作品,博文，收藏列表页自动加载更多***/
    /***kiki添加于20160112***/
    var flag = true;
    $(window).scroll(function(){
        var scrTop = $(this).scrollTop();
        var winHeight = $(document).height();
        var thisHeight = $(this).height();
        if(scrTop >= winHeight - thisHeight-900 && flag == true){
            if($('.more_opus').length == 0){
                if($('.collect_page').length > 0){    
                   addContent(selfUrl, 'collect_page', 'collect_page', casePageNum, caseNum); 
                }
                else if($('.case_page').length > 0){         
                   var cases = $('.cls_on').attr('data-type');
                   addContent(selfUrl, 'case_page',cases, casePageNum, caseNum); 
                }
                else if($('.blog_page').length > 0){
                   var blog = $('.blog_page').attr('data-type');
                   addContent(selfUrl, 'blog_page',blog, casePageNum, caseNum); 
                } 
            }  
            return false;          
        }     
    })


    //ajax post 请求
    function addContent(url, className, val) {
        flag = false;
        var page = arguments[3] ? arguments[3] : 2;
        var limit = arguments[4] ? arguments[4] : 1;
        $.ajax({
            type: "post",
            async: true,
            url: url, 
            data: {ajax_type:val, page:page, limit:limit},
            success:function(records){
                if(caseTypeNum - casePageNum * caseNum <= 0)
                {
                    flag = false;
                }
                else{
                    flag = true;
                }
                $(records).appendTo('.' + className);
                casePageNum++;
            }
        });
        return false;
    }

    //博文列表页分类选择效果
    $('.blog_class_list').change(function () {
        var typeId = $(this).val();
        var url = "log.php?uid=" + whoid + "&act=" + typeId + "&page=1";
        location.href = url;
    })



    //已关注，鼠标划过时变为取消关注状态
    $('#followBtn').mousemove(function(e){
        if($('#followBtn .care_font').text() != "关注")
        {
            $('#followBtn').removeClass('already_care');
            $('#followBtn').addClass('cancel_care');
            $('#followBtn .care_font').text("取消关注");
        }
    })
    //已关注，鼠标移走时变为已关注状态
    $('#followBtn').mouseout(function(e){
        if($('#followBtn .care_font').text() != "关注")
        {
            $('#followBtn').removeClass('cancel_care');
            $('#followBtn').addClass('already_care');
            $('#followBtn .care_font').text("已关注");
        }
    })
    //关注功能（关注，取消关注）
    $('#followBtn').bind('click', function() {
        var uid = whoid;
        var to8to_uid = SJB.GLOBAL_VAR.to8to_uid;
        if (!to8to_uid)
        {
            document.domain = 'shejiben.com';
            login.popLogin.init(1, 2);
            return false;
        }
        if (uid == to8to_uid) {
            alert('不能关注自己');
            return false;
        }
        else
        {
            var rel = 0;
            var url = userInfoIdUrl;
            if($('#followBtn .care_font').text() == '关注')
            {
                var gztype = 1;//关注
                rel = 1;
            }
            else
            {
                var gztype = 2;//取消关注
                rel = 2;
            }
                $.ajax({
                    url: url,
                    type: 'POST',
                    dataType: 'json',
                    data: {"gzvid" : uid, "gztype" : gztype, "rel" : rel},
                    success: function(data) {
                        if(data == 1)
                        {
                            $('#followBtn .care_font').text("已关注");
                            $('#followBtn').addClass('already_care');
                        }
                        if(data == 2)
                        {
                            $('#followBtn .care_font').text("关注");
                            $('#followBtn').removeClass('already_care');
                            $('#followBtn').removeClass('cancel_care');
                        }
                        if(data == 0)
                        {
                            alert(data.msg);
                        }
                    }
                });
            }
        })

    //对博文进行评论
    $('.send_comment_btn_post').bind('click', function() {
        var uid = whoid;
        var to8to_uid = SJB.GLOBAL_VAR.to8to_uid;
        if (!to8to_uid)
        {
            document.domain = 'shejiben.com';
            SJB.popLogin.init(2, 2);
            return false;
        }
        var url = "/sys_php/reply_new.php";
        var str = $('#comment_input').val();

        charLength = checkLength(str, true);
        if (charLength > 280) {
            alert('发送错误，已超过字数！');
            return false
        }

        if (str.replace(/\s+/,'') == "" || str == "<br>" || str == "说点什么吧…") {
            alert('您输入的内容为空，请重新输入！');
            $('comment_input').focus();
            return false
        }

        $.post(url, {
                'editor_content': str,
                'oid': lid,
                'type': 3,
                'uid': log_uid,
                'source': 'log_comment'
            },
            function(data)
            {
                    if (data.errorCode == 0)
                    {
                        $('#comment_input').val('');
                        alert('发布成功！请等待审核。');
                        return false
                    }
                    else
                    {
                        alert(data.errorMessage);
                    }

            },'json')
    })

    //对博文评论进行回复
    $('body').on('click', '.send_reply_btn', function(){
        var uid = whoid;
        var to8to_uid = SJB.GLOBAL_VAR.to8to_uid;
        var reply_content = $("#reply_337").val();
        var cid = $("#reply_337").attr('data-cid');
        if ($.trim(reply_content) == '') {
            alert('回复内容不能为空！');
            $("#reply_337").focus();
            return false;
        }
        else if (reply_content.length > 500)
        {
            alert('对不起输入内容必需小于500字符!');
            return false;
        }

        if (!to8to_uid)
        {
            document.domain = 'shejiben.com';
            SJB.popLogin.init(2, 2);
            return false;
        }
        var url = "/sys_php/reply_new.php";
        $.post(url, {
                'reply_content': reply_content,
                'source': 'comment_reply',
                'uid': log_uid,
                'type': 3,
                'oid': lid,
                'cid': cid
            },
            function(data)
            {
                if (data.errorCode == 0)
                {
                    var str = '<span class="reply_list">\
                        <a target="_blank" class="a_name">' + truename + '</a><i>：</i>\
                        <em>' + data.errorMessage + '</em>\
                        </span>';
                    $('.com_div01').parents('li').children().find('.com_reply').remove();
                    $('.com_div01').remove();
                    $('.ajax_reply_'+cid).html(str);
                    $('.ajax_reply_'+cid).hide();
                    $('.ajax_reply_'+cid).fadeIn(1000);
                    return false;
                }
                else
                {
                    alert(data.errorMessage);
                }

            },'json')

    });

    //c收藏列表页新建图集
    $('.btn_manage_pic').click(function(){
        var url = 'http://www.shejiben.com/my/edit_photos.php?act=edit_tuji&cid=0&source=homepage';
        var boxTitle = '新建图集';
        $.colorbox({
            iframe:false,
            href:url,
            opacity:"0.5",
            height:390,
            width:530,
            //html:'加载中...',
            initialWidth:0,
            initialHeight:0,
            close:'close',
            title:boxTitle,
            //transition:'none',
            onLoad:function(){
                $('#colorbox, #cboxOverlay, #cboxWrapper').css('border','none');
            },
            onComplete:function(){
                $("#cboxTopCenter").css("display","none");
            }
        });
    })

    //坚持长度
    var checkLength = function(strTemp) {
        var i,sum;
        sum = 0;
        for (i = 0; i < strTemp.length; i++) {
            if ((strTemp.charCodeAt(i) >= 0) && (strTemp.charCodeAt(i) <= 255)) {
                sum = sum + 1
            } else {
                sum = sum + 2
            }
        }
        return sum
    };
    //发布评论
    function uploadData(obj, i) {
        var hiddenUser;
        if ($('hiddenUser1')) {
            if ($('hiddenUser1').checked) {
                hiddenUser = $('hiddenUser').value = 1
            } else {
                hiddenUser = $('hiddenUser').value = 0
            }
        }
        var editor_content = $('editor_content').value;

        var re = /<img.+?>/gim;
        var aImg = $('editor_content').value.match(re);
        var imglen = 0;
        var yzm = '';
        if ($('yzm')) {
            yzm = $('yzm').value
        }
        if (aImg) {
            for (i = 0; i < aImg.length; i++) {
                imglen += aImg[i].length + 2
            }
        }
        if ($('editor_content').value.replace(/<.+?>/gim, '').length + imglen > 140) {
            alert('您输入内容必须低于140个字符！');
            oTextArea._textarea.focus();
            return false
        }
        // $('comment_verify').disabled = 'disabled';
        jq('#eliminate').fadeOut(0,
            function() {
                jq(this).text('').fadeIn(1000,
                    function() {})
            });
        if (i) {
            jq.post(url, {
                    'editor_content': editor_content,
                    'yzm': yzm,
                    'no_yzm': no_yzm,
                    'no_photo': no_photo,
                    'hiddenUser': hiddenUser,
                    'putoutreply': 'putoutreply'
                },
                function(r) {
                    if (r == 1) {
                        jq('h2#leaveAComment').fadeOut(0,
                            function() {
                                jq(this).text('验证码错误，发送失败!').fadeIn(1000,
                                    function() {
                                        jq('h2#leaveAComment').slideUp(800)
                                    })
                            })
                    } else if(r == -100){
                        alert('警告：您的文本中含有系统不允许的内容，被屏蔽。');
                    }else {
                        jq('<div class="overlay"></div>').fadeIn(1000,
                            function() {
                                if (jq('#comments li').length > 10) {
                                    jq('#comments li:last-child').remove()
                                }
                                // if (jq('#no_reply')) {
                                //     jq('#no_reply').remove()
                                // }
                                // jq('#comments').prepend('<li>' + r + '</li>').children(':last').height(jq('#comments li:last').height()).hide().slideUp(800)
                            });
                        oTextArea._textarea.value = '';
                        //jq('#eliminate').text('发布成功！请等待审核。').fadeIn(1000, function() {})
                        alert('发布成功！请等待审核。');
                    }
                    // $('comment_verify').disabled = '';
                    jq('#eliminate').slideUp(1000);
                    clear_Data();
                    return false
                })
        }
    }

    //异步获取关注状态(初始化关注状态)
    function fllowStatus() {
        var to8to_uid = SJB.GLOBAL_VAR.to8to_uid;
//        var uid = $('#followBtn').attr('rev');
        var uid = whoid;
        if (!to8to_uid) {
            return false;
        }
        var url = userInfoIdUrl;
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'json',
            data: 'followId=' + uid,
            success: function(data) {
                if (data.code == '1001') {
                    $('#followBtn').addClass('already_care');
                    $('#followBtn .care_font').text(data.msg);
                }
            }
        });
    }

    /**
     * 网页头部动态载入JS脚本
     * @param  {[string]} id  id属性值
     * @param  {[string]} url script标签的src属性值
     */
    function insertScript(id, url, callback) {
        var oScript = $('#' + id)[0];
        if (oScript) {
            oScript.parentNode.removeChild(oScript)
        };
        oScript = document.createElement('script');
        oScript.setAttribute('id', id);
        oScript.setAttribute('src', url);
        oScript.setAttribute('type', 'text/javascript');
        oScript.setAttribute('language', 'javascript');
        oScript.onload = function() {
            typeof callback === 'function' && callback.call(this, oScript);
        }
        var header = $('head')[0];
        header.appendChild(oScript)
    };
    //请求PHP，获取人气值
    function getUserData() {
        var server_host = SJB.GLOBAL_VAR.server_host;
        var href = server_host+'getuserdata.php?pos=homePage&uid='+whoid+'&s='+Math.random(5);
        insertScript('sInsertScript_userdata', href, function(data) {
            $('#popularily').html(visitorinfo.vnum);
        });
    }
    function init(){
        setMenuBar();
        setHeadBg();
        setToolPosition();
        replyComment();
        setCommentPosition();
        reservationDesigner();
        fllowStatus();
        getUserData();
        setMenuPosition.init({
            opusTop : $('.designer_opus').length < 1 ? false : $('.designer_opus').offset().top,
            commentTop : $('.owner_comment').length < 1 ? false : $('.owner_comment').offset().top,
            recordTop : $('.deal_record').length < 1 ? false : $('.deal_record').offset().top,
            aboutTop : $('.about_he').length < 1 ? false :  $('.about_he').offset().top
        });
    }
    module.exports = {
        init: init
        }

    });


