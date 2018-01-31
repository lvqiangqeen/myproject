define( function( require, exports, module ) {  
    require('layer');
    var showPhotoBox = require('http://static.shejiben.com/common/widgets/ui/photoBox.js?20170314');
    var collection = require('collection');
    var yuyue = require('yuyue');
    var lazyload = require('lazyload');
    var LazyObj = lazyload.lazyload($('img'));
    var login = require('login');
    var province = require('provinces');
    var bottomZb = require('bottomZb');
    var ask = require('ask');
    jQuery(document).ready(function(){
        // 所在位置下的折叠菜单
        $(".pageTag").hover(function() {
            $(this).find('ul').show();
        }, function() {
            $(this).find('ul').hide();
        });
        // ========== 底部招标 =============
        bottomZb.commonBottomZb.init();
        if($('#common_bottom_zb').length>0){
            $('#btn_bottom_zb').click(function(){
                //百度统计函数
                try{
                    _hmt && _hmt.push(['_trackEvent', 'sjandb', 'sjanxqydbljtj', '4_6']);
                }catch(e){
                }
            });
        }
        // ========== 预约设计师 =========
        province({
            elems : ['#User_Shen' , '#User_City' ],
            placeHolders: ['省/市', '市/地区']
        });
        $('.reservation').click(function() {
            var sendId = parseInt($(this).attr('data-id'));
            yuyue.free_yuyue.init(sendId,'','sjaltty','sjalttyyyzx','9_4');
        });
        // ========= 对图片提问 =========
        $('.caseInfo').on('click','.caseImgList .question',function(){
            var picId  = $(this).attr('data-id');
            ask.actionAsk.init(picId);
        }); 
        // ========= 收藏图片 ========
        $('.caseInfo').on('click','.caseImgList .collection',function(){
            var picId  = $(this).attr('data-id');
                picUrl = $(this).attr('data-src'); 
            collection.imageCollection.init(picId,picUrl);
        }); 
        // ======== 幻灯片 =========
        jQuery(".preview-box").click(function(){    /*处理图集当前列表*/
            var imgTitle = jQuery(this).attr('title');
            showPhotoBox.photoBoxZbGuide.init();
            showPhotoBox.photoBox.init(jQuery(this).attr('data-id'),currentPage,imgTitle);
            return false; 
        });



        //左侧分享的添加
        function imgShare(){
            var img_share = '<div class="img_share">'
                                +'<div class="share_top">'
                                    +'<a href="javascript:void(0)" class="share_con collect_btn" id="oneclick"><i></i><em class="s_num">'+ sc_number +'</em></a>'
                                    +'<a href="javascript:void(0)" class="share_con comment_btn" id="toImgComment"><i></i><em class="s_num">'+ pl_number +'</em></a>'
                                    +'<div class="share_con bdsharebuttonbox" data-tag="share_1"><i></i><a href="javascript:void(0)" class="s_num bds_count" data-cmd="count">0</a></div>'
                                +'</div>'
                                +'<div class="share_bottom" class="share_bottom">'
                                    +'<a href="javascript:void(0)" class="bottom_a01"></a>'
                                    +'<div class="show_code">'
                                        +'<i class="icon_arrow"></i>'
                                        +'<a href="http://www.shejiben.com/app/" target="_blank" class="app_code">'
                                            +'<em></em>'
                                            +'<p>扫描下载</p>'
                                            +'<p>设计本装进口袋</p>'
                                        +'</a>'
                                        +'<a href="javascript:void(0);" target="_blank" class="weixin_code">'
                                            +'<em></em>'
                                            +'<p>扫微信，获取10000套</p>'
                                            +'<p>家居设计案例</p>'
                                        +'</a>'
                                    +'</div>'
                                +'</div>'
                            +'</div>';
            $('body').append(img_share);
        }
        imgShare();
        //左边分享等的定位
        function shareColumnMark() {
            var topAd = 0;
            topAd = $('#top_add').is(':visible')?$('#top_add').height():0;
            var winWidth = $(window).width();
            var sHeight = $(".img_share").height();
            var sWidth = $(".img_share").width();
            var tWidth = (winWidth-990)/2;
            var imgTop = topAd+206;
            if(tWidth > sWidth){
                $(".img_share").css({'left':(tWidth-sWidth-12)+'px','top':imgTop});
            }
            else{
                $(".img_share").css({'left':0,'top':imgTop});
            }
        }
        shareColumnMark();
        //点击评论按钮跳转到评论区
        $('#toImgComment').click(function(){
            var imgComment = $('#image_comment').offset();
            $('body,html').animate({scrollTop:imgComment.top},1);
        })
        //调整窗口的大小时，重置工具栏的定位
        $(window).resize(function(){
            shareColumnMark();
        });
        // 百度分享代码
        window._bd_share_config={"common":{"bdSnsKey":{},"bdText":"","bdMini":"2","bdMiniList":false,"bdPic":"","bdStyle":"0","bdSize":"16"},"share":{"tag" : "share_1","bdSize" : 16}};with(document)0[(getElementsByTagName('head')[0]||body).appendChild(createElement('script')).src='http://bdimg.share.baidu.com/static/api/js/share.js?v=89860593.js?cdnversion='+~(-new Date()/36e5)];
        var bdComment = '';
        var bds_config = {};
        var bdpic = '';
        $(function(){
            bdComment = document.getElementById('thumb_intro') || ' ';
            bdpic     = $('.thumbnail').eq(0).attr('src') || '';
            if (bdComment != ' ') {
                bdComment = bdComment.innerHTML;
                bdComment = bdComment.replace(/\<br\>/g, '');
            }
            bds_config = {
                'bdText':"{$collection[NAME]}",
                'bdDesc':"推荐一组不错的装修设计图片，留着备用哦（分享自设计本）",
                'bdComment':bdComment,
                'bdPic':bdpic
            };
        });
        // 提交按钮可点与不可点,键盘输入提示文字隐藏
        $(".input_text").bind('keydown keyup change', function() {
            $(this).prev('label').hide();
            if(!$(this).val()==''){
                $(this).next('.com_div .sub_btn').removeAttr("disabled").css("background","#dd4f50");
            }
            else{
                $(this).next('.com_div .sub_btn').attr("disabled","disabled").css("background","#f79b9c");
            }
        });
        $(".input_text").blur(function(){
            if($(this).val()==''){
                $(this).prev('label').show();
            }
        });
        //点击回复出现回复框
        $(".com_div01").hide();
        $(".com_reply").click(function(){
            if($(this).next(".com_div01").is(':hidden')){
                $(this).next(".com_div01").show();
                $(this).parents('li').siblings().find('.com_div01').hide();
            }else{
                $(this).next(".com_div01").hide();
            }   
        })
        //点击回复框边框变红
        $(".input_text,.def_value").click(function(){
            if(!SJB.GLOBAL_VAR.to8to_uid){
                login.popLogin.init(1, 2);
            }else{
                $(this).parents(".com_div").css("border-color","#dd4f50");
            }
        })
        $(".input_text").blur(function(){
            $(this).parents(".com_div").css("border-color","#e3e3e3");
        })
        //点击默认文字时输入框获得焦点
        $('.def_value').click(function(){
            if($(this).length < 1){
                return false;
            }
            $(this).next('.input_text').focus();
        });
    });
    //对博文进行评论
    jQuery('.btn_submit_comment').click(function() {
        var uid = whoid;   //文章ID
        var to8to_uid = log_uid;   //当前用户ID
        if (!to8to_uid){
            document.domain = 'shejiben.com';
            login.popLogin.init(1, 2);
            return false;
        }
        var url = "/sys_php/reply_new.php";
        var str = jQuery('#comment_input').val();
        charLength = checkLength(str, true);
        if (charLength > 280) {
            alert('发送错误，已超过字数！');
            return false
        }
        if (str.replace(/\s+/,'') == "" || str == "<br>" || str == "说点什么吧…") {
            alert('您输入的内容为空，请重新输入！');
            jQuery('comment_input').focus();
            return false
        }
        jQuery.post(url, {
                'editor_content': str,
                'oid': lid,
                'type': 25,
                'uid': uid,
                'source': 'case_comment'
            },
            function(data)
            {
                jQuery('#comment_input').next('input').css('background','rgb(247, 155, 156)');
                if (data.errorCode == 0)
                {
                    alert('发布成功！请等待审核。');
                    jQuery('#comment_input').val('').blur(); 
                    jQuery('.sub_btn').attr("disabled","disabled").css("background","#f79b9c");
                    return false
                }
                else
                {
                    alert(data.errorMessage);
                }

            },'json')
    });
    //文字长度
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
    //对博文评论进行回复
    jQuery('.btn_submit_reply').click(function(){
        var uid = whoid;
        var to8to_uid = log_uid;
        var reply_content=jQuery(this).prev('#reply_337').val();
        var obj=jQuery(this);
        var cid = jQuery(this).prev('#reply_337').attr('data-cid');
        if (jQuery.trim(reply_content) == '') {
            alert('回复内容不能为空！');
            jQuery(this).prev('#reply_337').focus();
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
            showSingleLogin(2,2);
            return false;
        }
        var url = "/sys_php/reply_new.php";
        jQuery.post(url, {
                'editor_content': reply_content,
                'source': 'case_comment',
                'uid': uid,
                'type': 25,
                'oid': lid,
                'f_replyid': cid
            },
            function(data)
            {
                obj.css('background','rgb(247, 155, 156)');
                if (data.errorCode == 0)
                {
                    alert('发布成功！请等待审核。');
                    obj.prev('#reply_337').val('').blur();
                    jQuery('.sub_btn').attr("disabled","disabled").css("background","#f79b9c")
                    return false
                }
                else
                {
                    alert(data.errorMessage);
                }
            },'json')
    });
    //案例收藏
    jQuery(document).ready(function(){
        jQuery('#oneclick').click(function(){
            if($(this).attr('flag') != undefined && $(this).attr('flag') == 0){
                return false;
            }
            $(this).attr('flag',0);
            if (!log_uid){
                $('#oneclick').attr('flag',1);
                document.domain = 'shejiben.com';
                login.popLogin.init(1, 2);
                return false;
            }
            var url = "/sys_php/reply_new.php";
            jQuery.post(url, {
                    'source': 'case_sc',
                    'type': type,
                    'oid': lid
                },
                function(data){
                    $('#oneclick').attr('flag',1);
                    var errMsg = '收藏成功';
                    if (data.errorCode == 1 || data.errorCode == 2)   //收藏成功 / 已收藏
                    {
                        jQuery('#oneclick > em').html(data.errorMessage);
                        errMsg = (data.errorCode == 1) ? '收藏成功!':'您已收藏过该案例了!';
                        var html = '<div class="common_collection_success_msg common_collection_case_success_msg">'+
                                    '<div class="submit_status">'+
                                        '<span class="icon icon_sucess"></span>'+
                                        '<p class="tips_b">'+errMsg+'</p>'+
                                        '<p class="tips_s">可到"个人中心-我的收藏"查看</p>'+
                                    '</div>'+
                                    '<div class="app_tips">'+
                                        '<i class="icon_app_zb"></i>'+
                                        '<p>下载设计本APP</p><p>随时随地赏美图</p>'+
                                    '</div>'+
                                '</div>';
                        layer.open({
                            type:1,
                            content:html,
                            area:['430px','250px'],
                            title:'收藏案例',
                            closeBtn:true,
                            success:function(){
                            }
                        });
                    }
                    else{
                        alert(data.errorMessage);
                    }
                },'json')
        });

        // jQuery('body').on('click','.btn_red,#cboxClose',function(){
        //     jQuery('.container_popup').remove();
        //     jQuery.colorbox.close();
        // })
    });

    module.exports = {
    
    }
});