/**
 * 设计本公用JS模块,包含一些全局公用的函数，对象，变量等,所有页面默认都预加载main.js
 * 在原来common.js的基础上剔除了没有用到的函数以及一些对原型对象的操作
 * 新版的JS架构采用了seajs作为底层的模块加载框架
 *
 * @version 1.0
 * @author shejiben Team
 *
 */

define(function(require, exports, module) {

    //一些全局公用的变量，比如登录后的uid，昵称等,为了代码的规范，需要全局使用的变量都定义在这里
    var GLOBAL_VAR = {
        to8to_uid: getCookie('uid', 1), //登录用户id
        to8to_ind: getCookie('ind', 1), //登录用户类型，设计师or业主
        to8to_head: getCookie( 'headPhoto', 1 ),
        browser: getBrowser(), //浏览器类型
        server_host: getServerHost(),
        default_title: document.title
    }

    function getServerHost() {
        return (window.location.href.indexOf(".shejiben.com") != -1) ? 'http://www.shejiben.com/' : '/';
    }

    /**
     * 获取浏览器的内核版本，用于判断浏览器类型
     * @return object 包含浏览器内核信息的对象
     */
    function getBrowser() {
        var u = navigator.userAgent,
            app = navigator.appVersion;
        return {
            trident: u.indexOf('Trident') > -1, //IE内核
            presto: u.indexOf('Presto') > -1, //opera内核
            webKit: u.indexOf('AppleWebKit') > -1, //苹果、谷歌内核
            gecko: u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1, //火狐内核
            mobile: !!u.match(/AppleWebKit.*Mobile.*/), //是否为移动终端
            ios: !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), //ios终端
            android: u.indexOf('Android') > -1 || u.indexOf('Linux') > -1, //android终端或者uc浏览器
            androidPhone: u.indexOf('Android') > -1 && u.indexOf('Mobile') > -1,
            iPhone: u.indexOf('iPhone') > -1, //是否为iPhone或者QQHD浏览器
            iPod: u.indexOf('iPod') > -1, //是否为iPhone或者QQHD浏览器
            iPad: u.indexOf('iPad') > -1, //是否iPad
            winphone: u.indexOf('Windows Phone') > -1, //是否windows phone
            webApp: u.indexOf('Safari') == -1 //是否web应用程序
        };
    }

    /**
     * 设置cookie
     * @param {[string]} name  cookie的名称
     * @param {[string]} value  cookie的值
     * @param {[intger]} expire cookie的过期时间
     * @param {[string]} pre    cookie名的前缀
     * @param {[string]} domain cookie所在的域
     */
    function setCookie(name, value, expire, pre, domain) {
        if (!expire) {
            expire = 5000
        };
        if (pre) {
            name = 'to8to_' + name
        };
        var expiry = new Date();
        expiry.setTime(expiry.getTime() + expire);
        var domain_url = '';
        if (domain) domain_url = 'domain=' + domain + ';';
        document.cookie = name + '=' + value + ';expires=' + expiry.toGMTString() + ';path=/;' + domain_url
    }

    /**
     * 获取cookie
     * @param  {[string]} name 需要获取的cookie名
     * @param  {[string]} pre  如果需要带上前缀则使用此参数
     * @return {[string]} 返回对应的cookie值,不存在则返回空字符串
     */
    function getCookie(name, pre) {
        if (pre) {
            name = 'to8to_' + name
        };
        var r = new RegExp("(\\b)" + name + "=([^;]*)(;|$)");
        var m = document.cookie.match(r);
        return (!m ? "" : decodeURIComponent(m[2]))
    }

    /**
     * 图片自适应位置方法
     * @param  {[object]} obj 需要自适应位置的图片
     * @param  {[intger]} w   图片自适应的最大宽度
     * @param  {[intger]} h   自适应的最大高度
     */
    function autoSize(obj, w, h) {
        var oIMG = new Image();
        oIMG.onload = function() {
            var oW = this.width;
            var oH = this.height;
            var tax = 1;
            if (oW > w || oH > h) tax = (oW / oH) > (w / h) ? (w / oW) : (h / oH);
            obj.style.marginLeft = (w - Math.floor(oW * tax)) / 2 + "px";
            obj.style.marginTop = (h - Math.floor(oH * tax)) / 2 + "px";
            obj.width = oW * tax;
            obj.height = oH * tax
        };
        oIMG.src = obj.src
    };

    function autoSize_H(obj, h) {
        var oIMG = new Image();
        oIMG.onload = function() {
            var oh = this.height;
            if (oh > h) {
                obj.height = h;
                obj.style.marginTop = '0px';
                obj.parentNode.style.background = '#fff';
            } else {
                obj.height = this.height;
                obj.style.marginTop = (h - Math.floor(oh)) / 2 + 'px';
                obj.parentNode.style.background = '#FAFAF6';
            }
        };
        oIMG.src = obj.src
    };

    function autoSize_w(obj, w) {
        var oIMG = new Image();
        oIMG.onload = function() {
            var oW = this.width;
            if (oW > w) {
                obj.width = w;
                obj.height = Math.floor((this.height) * (w / this.width))
            }
        };
        oIMG.src = obj.src
    };

    /**
     * 滚动条返回顶部
     * @param  {[mixed]} o 如果o为字符串，则默认标识元素的id，如果为object，则默认为元素对象
     *                     如果为int，则默认为需要滚动到的位置
     */
    function scroll2top(o) {
        var top = 0;
        if (typeof o == 'string') {
            var node = $(o)
        } else if (typeof o == 'object') {
            var node = o
        } else if (typeof o == 'number') {
            top = o;
            if (top === 0) {
                backToTop();
                return false;
            }
        }
        if (node) {
            top += node.offsetTop
        };
        window.scrollTo(0, top);
    };

    /**
     * 判断字符是否存在数组中
     * @param  {[string]} value 要寻找的字符串
     * @param  {[array]} arr   目标数组
     * @return boolen
     */
    function in_array(value, arr) {
        if (!arr || arr.length == 0) return false;
        var flag = false;
        for (var i = 0, j = arr.length; i < j; i++) {
            if (arr[i] == value) {
                flag = true;
            }
        };
        return flag
    };

    /**
     * 字符串截取函数，如果给定字符串小于指定长度，则返回源字符串
     * @param  {[string]} str 需要截取的字符串
     * @param  {[intger]} len 要截取的长度
     * @return {[string]}     截取后的字符串
     */
    function cutstr(str, len) {
        var str_length = 0;
        var str_len = 0;
        str_cut = new String();
        str_len = str.length;
        for (var i = 0; i < str_len; i++) {
            a = str.charAt(i);
            str_length++;
            if (escape(a).length > 4) {
                //中文字符的长度经编码之后大于4
                str_length++;
            }
            str_cut = str_cut.concat(a);
            if (str_length >= len) {
                str_cut = str_cut.concat("...");
                return str_cut;
            }
        }
        //如果给定字符串小于指定长度，则返回源字符串；
        if (str_length < len) {
            return str;
        }
    }

    /**
     * 网页头部动态载入JS脚本
     * @param  {[string]} id  id属性值
     * @param  {[string]} url script标签的src属性值
     */
    function insertScript(id, url) {
        var oScript = $('#' + id)[0];
        if (oScript) {
            oScript.parentNode.removeChild(oScript)
        };
        oScript = document.createElement('script');
        oScript.setAttribute('id', id);
        oScript.setAttribute('src', url);
        oScript.setAttribute('type', 'text/javascript');
        oScript.setAttribute('language', 'javascript');
        var header = $('head')[0];
        header.appendChild(oScript)
    };

    /**
     * 动态加载JS脚本
     */
    function jsLoader(id) {
        this.load = function(f) {
            var oTags = document.getElementsByTagName('script');
            for (i = oTags.length - 1; i >= 0; i--) {
                var src = oTags[i].src;
                if (src && src.indexOf(f) > -1) {
                    this.onsuccess();
                    return
                }
            }
            var s = document.createElement('script');
            if (id) var header = document.getElementById(id);
            else var header = document.getElementsByTagName('head').item(0);
            s.setAttribute('src', f);
            s.setAttribute('type', 'text/javascript');
            s.setAttribute('language', 'javascript');
            header.appendChild(s);
            var _self = this;
            s.onload = s.onreadystatechange = function() {
                if (this.readyState && this.readyState == "loading") {
                    return
                };
                _self.onsuccess()
            };
            s.onerror = function() {
                header.removeChild(s);
                _self.onfailure()
            }
        };
        this.onfailure = function() {};
        this.onsuccess = function() {}
    };

    function newshowSingleLogin(id, n) {
        var oJsLoader = new jsLoader('bd_statistics');
        var h = 268;
        if ( $.browser.msie === true && $.browser.version == '6.0' ) h = 290;
        if (typeof($) != 'undefined') {
            if (typeof($.fancybox) != 'undefined') {
                $(document).ready(function($) {
                    $.fancybox('<iframe src="http://www.shejiben.com/new_pop_login.html?id=' + parseInt(id) + '&new=' + parseInt(n) + '" width="487" frameborder="0" height="' + h + '" name="new"></iframe>', {
                        centerOnScroll: true,
                        'hideOnOverlayClick': false,
                        'editcssid': 'fancybox-wraps',
                        onClosed: function() {}
                    })
                })
            } else {
                oJsLoader.onsuccess = function() {
                    $(document).ready(function($) {
                        $.fancybox('<iframe src="http://www.shejiben.com/new_pop_login.html?id=' + parseInt(id) + '&new=' + parseInt(n) + '" width="487" frameborder="0" height="' + h + '" name="new"></iframe>', {
                            centerOnScroll: true,
                            'hideOnOverlayClick': false,
                            'editcssid': 'fancybox-wraps',
                            onClosed: function() {}
                        })
                    })
                };
                oJsLoader.load("http://www.shejiben.com/gb_js/jquery.fancybox.js")
            }
        } else showSingleLogin(id);
        return false
    };

    /**
     * 登录弹框
     * @param  {[intger]} id ignore
     * @param  {[intger]} n  n为2时表示需要设置document.domain为shejiben.com
     */
    function showSingleLogin(id, n, referrer) {
        try {
            referrer = referrer ? referrer : parent.window.location.href;   
        } catch ( e ) {
            referrer = '';
        }
        
        var goUrl = 'http://www.shejiben.com/pop_login.htm?id=' + parseInt(id) + '&new=' + parseInt(n) + '&referrer=' + referrer;
        
        /**editPhotoCat
        * 原弹框
        var oJsLoader = new jsLoader();
        oJsLoader.onsuccess = function() {
            editPhotoCat(goUrl, '登陆', 486, 308)
        };
        oJsLoader.load('http://www.shejiben.com/gb_js/popup.js');
        */

        //弹框切换到colorbox
              //  editPhotoCat(goUrl,'');

        seajs.use('colorbox',function (){
            jQuery.colorbox({
                width: 380,
                height: 400,
                transition:"none",
                title:'登录',
                //fixed:true,
                opacity:'0.4',
                //inline:false,
                //escKey:false,
                preloading:false, 
                //overlayClose:false,
                //scrolling:false, 
                iframe:true,
                href:goUrl,
                onComplete:function(){
                    jQuery('#cboxTitle').css({'width':'100%','height':'40px','background':'#333','top':'-32px','left':'0','color':'#999','line-height':'42px','text-indent':'20px','font-size':'16px'});
                    jQuery('#colorbox').css({'border':'none'});
                    jQuery('#cboxClose').css({'background':'url(http://img.shejiben.com/global.png) no-repeat -61px -128px','top':'-16px','right':'20px'});
                    

                },
                onClosed:function (){
 
                }
            });
        });
    }

    /**
     * 判断参数是否为数字
     */
    function isDigit(num) {
        var regs = /^\d+$/;
        if (regs.test(num)) {
            return true
        } else {
            return false
        }
    };

    function greet_text() {
        var text = "";
        var dt = new Date();
        var hours = dt.getHours();
        var username = getCookie('username', 1);
        if (typeof(username) == 'undefined' || username == "") {
            username = '您还未登陆，'
        } else {
            username = '欢迎来到设计本，' + username
        }
        var uid = getCookie('uid', 1);
        $("#xb_greet").html(username);
    };

    /**
     * 登录检测，以及登陆后的一些DOM处理
     */
    function blogcheck() {
        username = getCookie('username', 1);
        if (typeof(username) != 'undefined' && username != "" && username != "deleted") {
            nick = cutstr(getCookie('to8to_nick'), 10);
            mysite = "http://www.shejiben.com/" + GLOBAL_VAR.to8to_ind + "/" + GLOBAL_VAR.to8to_uid + '/';
            var In_jiaoyi_center = false;
            if (typeof(jiaoyi_center) != 'undefined' && jiaoyi_center == 1) {
                In_jiaoyi_center = true
            };
            //"http://pic.shejiben.com/user/"+(GLOBAL_VAR.to8to_uid%100)+"/headphoto_"+GLOBAL_VAR.to8to_uid+"_e.jpg";
            HeadPhoto = getCookie('headPhoto', 1);
            HeadPhoto = typeof HeadPhoto != 'undefined' ? HeadPhoto : "http://pic.shejiben.com/user/" + (GLOBAL_VAR.to8to_uid % 100) + "/headphoto_" + GLOBAL_VAR.to8to_uid + "_e.jpg";
            if ($('#add_qq_lo')) $('#add_qq_lo').hide();
            if ($('#add_wb_lo')) $('#add_wb_lo').hide();
            if ($('#add_tishi_mes')) $('#add_tishi_mes').show();
            if (GLOBAL_VAR.to8to_ind == 'sjs'){
                var uPdata  =  '<li><a href="http://www.shejiben.com/my/order_list.php" class="up">我的派单</a></li>';
                    uPdata +=  '<li><a href="http://www.shejiben.com/my/my_project.php?obj=2&act=2" class="jy">我的交易</a></li>';
                    uPdata +=  '<li><a href="http://www.shejiben.com/my/photos.php" class="bj">我的作品</a></li>';
                    uPdata +=  '<li><a href="http://www.shejiben.com/my/gold_list.php" class="up">我的金币</a></li>';
                    uPdata +=  '<li><a href="http://www.shejiben.com/my/pay.php" class="up">我的余额</a></li>';
                    uPdata +=  '<li><a href="http://www.shejiben.com/my/manage_account.php" class="up">账号设置</a></li>';
            }else{
                var uPdata  = '<li><a href="http://www.shejiben.com/my/ideabooks.php" class="bj">我的收藏</a></li>';
                    uPdata += '<li><a href="http://www.shejiben.com/my/ask.php" class="bj">我的问答</a></li>';
                    uPdata += '<li><a href="http://www.shejiben.com/my/my_project.php?obj=1" class="jy">我的交易</a></li>';
                    uPdata += '<li><a href="http://www.shejiben.com/my/gold_list.php" class="up">我的金币</a></li>';
                    uPdata += '<li><a href="http://www.shejiben.com/my/pay.php" class="up">我的余额</a></li>';
                    uPdata += '<li><a href="http://www.shejiben.com/my/manage_account.php" class="up">账号设置</a></li>';                   
            }   

            var loginhtml = '';

            if ($('#nav_login')) {
                var my_index_a = '';
                if (typeof $ != 'undefined') {
                    $.ajax({
                        url: 'http://www.shejiben.com/getuserdata.php?s=1&pos=getLoginUserInfo',
                        dataType:'jsonp',
                        success:function(data) {    
                            if(nick == ''){
                                nick = data.nick;
                            }
                            if(GLOBAL_VAR.to8to_ind == 'sjs'){
                                my_index_a = '<li><a href="' + data.blog_url+ '" class="my_index_ad">我的主页</a></li>';
                            }               
                            $('#nav_login').html('<a href="http://www.shejiben.com/my/" class="title" id="bg" rel="1" hidefocus><span class="nick">' + nick + '</span></a><ul class="cz"><li><a href="http://www.shejiben.com/my/" class="my">个人中心</a></li>' + my_index_a + uPdata + '<li><a href="http://www.shejiben.com/logout.php?uid=' + GLOBAL_VAR.to8to_uid + '" class="tc">退出</a></li></ul>');
                        }
                    });
                }   
            }
        }
        $('#more_nav').bind('mouseover', function(e) {
            if (isMouseLeaveOrEnter(e, this)) {
                $('#m')[0].className = 'm m_on';
                $('#moreing').show();
            }
        });
        $('#more_nav').bind('mouseout', function(e) {
            if (isMouseLeaveOrEnter(e, this)) {
                $('#m')[0].className = 'm';
                $('#moreing').hide();
            }
        });
        $('#more_nav_pic').bind('mouseover', function(e) {
            if (isMouseLeaveOrEnter(e, this)) {
                $('#m_pic')[0].className = 'm m_on';
                $('#moreing_pic').show();
            }
        });
        $('#more_nav_pic').bind('mouseout', function(e) {
            if (isMouseLeaveOrEnter(e, this)) {
                $('#m_pic')[0].className = 'm';
                $('#moreing_pic').hide();
            }
        });
    };

    /***
     * 鼠标悬浮在用户头像或者名称上面时显示用户信息
     * 悬浮框，正常情况下是在下面显示
     * 1.当下面显示的高度超出浏览器的可视区域的高度，那么在上面显示
     */
    function showUserInfo() {
        if (typeof(jq) != 'undefined' && jq(".showUserInfo").size() > 0) {
            var handle = null;
            var handle1 = null;
            jq(".showUserInfoDiv").live('mouseover', function() {
                clearTimeout(handle1);
                jq(this).show();
            }).live('mouseout', function() {
                jq(this).hide();
            });

            jq(".showUserInfo").live('mouseover', function() {
                //页面可视区域的高度
                var wH = jq(window).height();
                //this的坐标
                var tTop = jq(this).offset().top;
                var tLeft = jq(this).offset().left;
                //this的宽高
                var tW = jq(this).width();
                var tH = jq(this).height();
                var cH = tTop - jq(window).scrollTop();
                var aimTop = 0;
                var flag = 0;

                if (cH + 200 + tH > wH) {
                    aimTop = tTop - 193 + 'px';
                    flag = 1;
                } else {
                    aimTop = tTop + tH + 'px';
                }
                var aimLeft = tLeft - 48 + parseInt(tW / 2);
                //content的宽度，当在悬浮框在右边，超过content的宽度时，调用第三种样式
                if (jq("#content").size() > 0) {
                    var conLeft = jq("#content").offset().left;
                    if (aimLeft + 310 > conLeft + 990) {
                        aimLeft = tLeft - 325 + parseInt(tW / 2);
                        flag = (flag == 1) ? 3 : 2;
                    }
                }
                aimLeft = aimLeft + 'px';
                //获取信息
                var uid = jq(this).attr("itemData");
                if (uid) {
                    handle = setTimeout("getUserInfo(" + uid + ",'" + aimLeft + "','" + aimTop + "'," + flag + ");", 200);
                }
            }).live('mouseout', function() {
                clearTimeout(handle);
                if (jq(".showUserInfoDiv").size() > 0) {
                    handle1 = setTimeout('jq(".showUserInfoDiv").hide();', 300);
                }
            });
        }
    }

    /**
     * 悬浮框中获取用户数据的方法
     * @param  {[intger]} uid   用户id
     * @param  {[type]} aimLeft ignore
     * @param  {[type]} aimTop  ignore
     * @param  {[type]} flag    ignore
     */
    function getUserInfo(uid, aimLeft, aimTop, flag) {
        var url = "http://www.shejiben.com/getuserdata.php?s=1&pos=showUserInfo";
        jq.post(url, {
            'uid': uid
        }, function(msg) {
            if (msg == 0) return false;
            var d_class = '';
            var dl_class = '';
            var app_class = msg.app.status ? 'app-login' : 'app-nologin',
                app_title = msg.app.status ? '手机客户端在线' : '手机客户端离线';
            d_class = (flag == 1) ? 'showUserInfoDiv2' : d_class;
            d_class = (flag == 2) ? 'showUserInfoDiv4' : d_class;
            d_class = (flag == 3) ? 'showUserInfoDiv3' : d_class;
            dl_class = (flag == 1 || flag == 3) ? 'dl2' : dl_class;

            var str = '<div class="showUserInfoDiv ' + d_class + '" style="left:' + aimLeft + ';top:' + aimTop + '"><div class="mouseDiv"><dl class="' + dl_class + '">';
            str += '<dt><img width="60" height="60" src="' + msg.headphoto + '" alt="' + msg.truename + '" title="' + msg.truename + '" /></dt>';
            str += '<dd class="dd1"><a href="' + msg.homepage + '"  class="username">' + msg.truename + '</a> <span class="sjuser ';
            if (msg.goodlevel == 5)
                str += 'utypezm';
            else if (msg.goodlevel == 4)
                str += 'utypejy';
            else if (msg.goodlevel == 3)
                str += 'utypexr';
            else if (msg.goodlevel == 2)
                str += 'utypevip';
            str += '"></span>';
            if (msg.vip)
                str += ' <span class="sjuser uvip" title="个人身份认证"></span>';
            if (!msg.app.hide) {
                str += '<span class="' + app_class + '" title="' + app_title + '"></span>';
            }
            str += '</dd><dd>' + msg.type;
            if (msg.shen != '' || msg.city != '') {
                str += '(' + msg.shen;
                if (msg.city != '') {
                    str += ',' + msg.city;
                }
                str += ')';
            }
            str += '</dd><dd>作品数 <span class="fontgreen">' + msg.pic_num + '张</span></dd>';
            str += '</dl>';
            str += '<div class="introduce"><p class="p1">介绍:</p><p class="p2" title="' + msg.introduce + '">' + msg.introduce_html + '</p></div>';
            str += '<div class="oper">';
            str += '<span class="lianxi"><a href="' + msg.homepage + '" target="_blank">联系方式</a></span>';
            if (msg.follow == 1)
                str += '<span class="isgz"><a href="javascript:;">已关注</a>　<a href="javascript:;" onclick="followUser(this)" rev="' + msg.id + '" class="cancel"><label>取消</label><input type="hidden" name="url" value="' + msg.homepage + '" /><input type="hidden" name="name" value="' + msg.truename + '" /></a></span>';
            else
                str += '<span class="nogz"><a href="javascript:;" onclick="followUser(this)" rev="' + msg.id + '"><label>加关注</label><input type="hidden" name="url" value="' + msg.homepage + '" /><input type="hidden" name="name" value="' + msg.truename + '" /></a></span>';

            str += '</div></div></div>';
            //如果存在一个悬浮框，先清除
            if (jq(".showUserInfoDiv").size() > 0) {
                jq(".showUserInfoDiv").remove();
            }
            jq("body").append(str);
        }, 'json');
    }

    /**
     * 悬浮框中的关注方法，与showUserInfo和getUserInfo一起使用
     */
    function followUser(obj) {
        var rev = obj.rev;
        var url = 'http://www.shejiben.com/sjs/index.php';
        if (!GLOBAL_VAR.to8to_uid) {
            showSingleLogin(0, 2);
            return false;
        }
        if (GLOBAL_VAR.to8to_uid == rev) {
            alert('不能关注自己');
        } else {
            var name = jq(obj).children("input[name=name]").val();
            var uurl = jq(obj).children("input[name=url]").val();
            if (jq(obj).children('label').html() == '加关注') { //点击关注
                jq.post(url, {
                    'uid': GLOBAL_VAR.to8to_uid,
                    'tag': 1,
                    'gzvid': rev,
                    'gztype': "1",
                    'rel': 0,
                    'url': uurl,
                    'name': name
                }, function(data) {
                    var thisParent = jq(obj).parent(".nogz");
                    thisParent.html('<a href="javascript:;">已关注</a>　<a href="javascript:;" rev="' + rev + '" onclick="followUser(this)" class="cancel"><label>取消</label><input type="hidden" name="url" value="' + uurl + '" /><input type="hidden" name="name" value="' + name + '" /></a>');
                    thisParent.removeClass("nogz");
                    thisParent.addClass("isgz");
                });
            } else {
                jq.post(url, {
                    'gzvid': rev,
                    'gztype': "2",
                    'rel': 0
                }, function(data) { // 点击取消关注
                    var thisParent = jq(obj).parent(".isgz");
                    thisParent.html('<a href="javascript:;" onclick="followUser(this)" rev="' + rev + '"><label>加关注</label><input type="hidden" name="url" value="' + uurl + '" /><input type="hidden" name="name" value="' + name + '" /></a>');
                    thisParent.removeClass("isgz");
                    thisParent.addClass("nogz");
                });
            }
        }
    }

    /**
     * 点击预约设计师
     * @param  {[intger]} toid    需要预约的设计师的id
     */
    var free_yuyue ={
        init:function(toid,byid){
            document.domain = 'shejiben.com';
            var _this = this;
            _this.closeColorBox(); 
            _this.insetErrorMsg(); 
            //未登录        
            to8to_uid = (typeof byid === "undefined") ? (GLOBAL_VAR.to8to_uid) : byid;
            if ( !to8to_uid ) {
                showSingleLogin( 1, 2 );
                return false;
            }  
            if(to8to_uid == toid){

                _this.showErrorBox('#msg_reservation_myself');
                return false;
            }
            jQuery.ajax({
                type: "post",
                url: 'http://www.shejiben.com/add_contact.php?toid='+toid,
                data: {ajax_type: 'reserve_page', userId: to8to_uid, sjsId: toid},
                dataType:'json',
                success:function(records) {
                    if(records == 1){
                        _this.showErrorBox('#msg_reservation_post');
                        return false;
                    }
                    if(records == 2){
                        _this.showErrorBox('#msg_reservation_ten');
                        return false;
                    }
                    if(records == 3){
                        _this.showErrorBox('#msg_reservation_sjs');
                        return false;
                    }
                    require.async('colorbox', function(){
                        jQuery.colorbox({
                            width: 540,
                            height: 450,
                            transition:"none",
                            title:false,
                            opacity: "0.5",
                            iframe: true,
                            overlayClose : false, //点击其他区域不关闭弹窗
                            href: 'http://www.shejiben.com/add_contact.php?toid='+toid,
                            onComplete: function() {
                                jQuery('#cboxClose').hide();
                                jQuery('#cboxTitle').css({'top':'-40px'});
                                jQuery('#colorbox').css({'padding-bottom':'32px'});
                                jQuery('#cboxContent').css({'margin-top':'0'});
                                jQuery('#cboxLoadedContent').css({'height':'450px'});
                            },
                            onClosed: function(){
                                revertCss();
                                jQuery('#colorbox').css({'padding-bottom':'50px'});
                            }
                        });
                    });
                }
            });
        },
        insetErrorMsg:function(){
            var html='<div class="clolorbox_msg" style="display:none;">\
                        <div class="clolorbox_msg_error" id="msg_reservation_myself">\
                            <em class="ico_error_close"></em><em class="ico_warn_b"></em><span class="msg_b">对不起，不能向自己发起预约！</span>\
                        </div>\
                        <div class="clolorbox_msg_error" id="msg_reservation_post">\
                            <em class="ico_error_close"></em><em class="ico_warn_b"></em><span class="msg_b">对不起，您今天已经预约过该设计师了！</span>\
                        </div>\
                        <div class="clolorbox_msg_error" id="msg_reservation_ten">\
                            <em class="ico_error_close"></em><em class="ico_warn_b"></em><span class="msg_b">对不起，一天只能预约5个设计师！</span>\
                        </div>\
                        <div class="clolorbox_msg_error" id="msg_reservation_sjs">\
                            <em class="ico_error_close"></em><em class="ico_warn_b"></em><span class="msg_b">您不是业主，不能发起预约!</span>\
                        </div>\
                    </div>';
            jQuery('body').append(html);  
        },
        showErrorBox:function(content){
            require.async( 'colorbox', function(){
                jQuery.colorbox({
                    width: 540,
                    height: 200,
                    opacity: "0.5",
                    inline: true,
                    href:content,
                    overlayClose : false, //点击其他区域不关闭弹窗
                    onComplete: function() {
                        jQuery('#cboxClose').hide();
                        jQuery('#cboxTitle').css({'top':'-40px'});
                        jQuery('#colorbox').css({'padding-bottom':'32px'});
                        jQuery('#cboxContent').css({'margin-top':'0'});
                        jQuery('#cboxLoadedContent').css({'height':'450px'});
                    }
                });
            });

        },
        closeColorBox:function(){
            jQuery('.clolorbox_msg_error .ico_error_close').live('click',function(){
                jQuery('.clolorbox_msg').remove();
                parent.jQuery.colorbox.close();
                var t = setTimeout(function(){
                    revertCss();
                    jQuery('#colorbox').css({'padding-bottom':'50px'});
                },500);

            });
        }
    }


    function AddFollowNew (i){
        i = typeof i != 'undefined' ? i : 0;
        $('.guanzhuA').live( 'click', function(){
            var obj = this;
            var url = 'http://www.shejiben.com/sjs/index.php';
            if(!GLOBAL_VAR.to8to_uid) {
                showSingleLogin(i,2);
            }
                
            if( GLOBAL_VAR.to8to_uid == this.rev) {
                alert('不能关注自己');
            } else {
                if($(this).children('span').html()=='+ 加关注' || $(this).children('span').html()=='加关注')  // 点击关注
                {
                    $(obj).children('span').html('已关注');
                    if($(obj).attr('data')==2){//找设计师界面
                        $(obj).addClass('hasguanzhuA');
                    }
                    $.post(url,{tag:i, uid : GLOBAL_VAR.to8to_uid, 'gzvid': this.rev, 'gztype': "1", 'rel': 0, 'url':$(this).children("input[name=url]").val(), 'name':$(this).children("input[name=name]").val() },function(data) {

                    });
                }
                else
                {
                    $.post(url,{tag:i, uid : GLOBAL_VAR.to8to_uid, 'gzvid': this.rev, 'gztype': "2", 'rel': 0 },function(data) {    // 点击取消关注
                        // $('guanzhuA').className='follow';
                        if($(obj).attr('data')==1) {
                            $(obj).children('span').html('加关注');
                        } else if ($(obj).attr('data')==2){//找设计师界面
                            $(obj).children('span').html('加关注');
                            $(obj).removeClass('hasguanzhuA');
                        }else {
                            $(obj).children('span').html('+ 加关注');
                        }
                    });
                }
            }
        });
    }

    /**
     * 网页头部搜索表单的验证
     */


    //验证搜索表单
    function checkSearchForm() {
        var search_q = $('#search_val').val();
        if(search_q == '请输入搜索关键词')
        {
            $('#search_val').focus();            
            return false;
        }
    }


    //搜索表单获取焦点时
    function searchFormOnFocus()
    {
        $("#search_val").focus(function(){
            var search_q = this.value;      
            if(search_q == '请输入搜索关键词')
            {               
                this.value = '';                
            }  
            /*** 搜索无内容时不跳转(kiki添加于20160328) ***/
            $('#quicksearch').bind('keydown',function(e){        
                e = e || window.event;
                search_q = $("#search_val").val();
                if(e.which == 13){
                    if(search_q == '请输入搜索关键词' || search_q ==''){   //无输入内容时禁用回车事件
                        e.preventDefault();         
                    }  
                    else{
                        $(this).unbind('keydown');    //有内容时进行搜索
                    }           
                }
            })           
        });

    }

    //搜索表单离开焦点是
    function searchFormOnBlur()
    {
        $("#search_val").blur( function () {
            if(this.value == '' || this.value == '请输入搜索关键词')
            {
                this.value='请输入搜索关键词'
            }
        } );

    }

    /**
     * 头部搜索初始化数据
     */
    function searchFun(obj, arr, urlArr) {
        obj = parseInt(obj) > 0 ? obj : 1;
        $('#s_zsj').html('');

        for (var i = 0; i < arr.length; i++) {
            if (arr[i] != obj) {
                $('#s_zsj').html($('#s_zsj').html() + '<a class="search_tags clickToSearch" href="javascript:;" data-id="' + arr[i] + '">' + urlArr[0][arr[i]][0][3] + '</a>');
            }
        }
        if(obj == 4 || obj == 5 || obj == 6){
            obj = 3;
        }
        if(obj == 8 ){
            obj = 1;
        }
        $('#searchType').val(obj);
        $('#search_title').html(urlArr[0][obj][0][3]);
        $('#quicksearch').attr('action', urlArr[0][obj][0][0]);
        $('#search_val').attr('name', urlArr[0][obj][0][1]);
//      $('#search_val').val(urlArr[0][obj][0][2]);
        $('#s_zsj').hide();
        var searchW = $('search_span').offsetWidth;
        $('#s_zsj').css('width', (searchW - 2) + 'px');
    }

    /**
     * 解决ie下 onmouseover和onmouseout冒泡的函数
     * 思路为判断当前执行mouse事件的元素是否为子元素，是则不执行事件
     */
    function isMouseLeaveOrEnter(e, handler) {
        if (!e) e = window.event;
        if (e.type != 'mouseout' && e.type != 'mouseover') return false;
        var reltg = e.relatedTarget ? e.relatedTarget : e.type == 'mouseout' ? e.toElement : e.fromElement;
        while (reltg && reltg != handler)
            reltg = reltg.parentNode;
        return (reltg != handler);
    }

    /**
     * 搜索框相关事件绑定
     */
    function searchBannerEvent(arr, urlArr) {
        if ($('#search_span').length) {
            $('#search_span').mouseover(function(e) {
                if (isMouseLeaveOrEnter(e, this)) {
                    $('#s_zsj').show();
                }
            });
            $('#search_span').mouseout(function(e) {
                if (isMouseLeaveOrEnter(e, this)) {
                    $('#s_zsj').hide();
                }
            });
            $('body').on('click','.clickToSearch', function() {
                var typeId = parseInt($(this).attr('data-id'));
                searchFun(typeId, arr, urlArr);
            });
        }
    }

    /**
     * 绑定顶部广告相关事件
     */
    function billingEvent() {
        var billing = this;
        this.li_length = 1;
        if ($('#top_add_close').length) {

            $('#top_add_close').click(function() {

                if ($("#top_add").length) {
                    $("#top_add").hide();
                }
                //新图集编辑页的顶部menu需要根据页面高度来自适应，所以关闭广告后需要重新设置其css属性
                if ($('#save_pic').length) {
                    $('#save_pic').css('top', '160px');
                }
                document.cookie = 'to8to_top_add=1;path=/;domain=shejiben.com';
            });

            var stop_in = setInterval(function() {
                billing.changeAd();
            }, 2000);
            $('#top_add').mouseover(function() {
                clearInterval(stop_in);
            })
            $('#top_add').mouseout(function() {
                stop_in = setInterval(function() {
                    billing.changeAd();
                }, 2000);
            })
        }
        this.changeAd = function() {
            if (this.li_length < $('.topAdLi').size()) {
                $("#topAdUl").css('marginTop', -60 * this.li_length + 'px');
                this.li_length = this.li_length + 1;
            } else {
                $("#topAdUl").css('marginTop', '0');
                this.li_length = 1;
            }
        }

        if (document.getElementById('navi_designer_guide') && document.getElementById('navi_yezhu_guide')) {
            document.getElementById('navi_designer_guide').onmouseover = function(e) {
                if(isMouseLeaveOrEnter(e, this)){
                    document.getElementById('designer_guide').style.display = '';
                }
            }

            document.getElementById('navi_designer_guide').onmouseout = function(e) {
                if(isMouseLeaveOrEnter(e, this)){
                    document.getElementById('designer_guide').style.display = 'none';
                }
            }

            document.getElementById('navi_yezhu_guide').onmouseover = function(e) {
                if(isMouseLeaveOrEnter(e, this)){
                    document.getElementById('yezhu_guide').style.display = '';
                }
            }

            document.getElementById('navi_yezhu_guide').onmouseout = function(e) {
                if(isMouseLeaveOrEnter(e, this)){
                    document.getElementById('yezhu_guide').style.display = 'none';
                }
            }
        }

    }

    /**
     * 用户的QQ和sina的状态，用于判断是否关注了设计本的官方账号
     */
    function tencent_sina_status() {
        if (GLOBAL_VAR.to8to_uid) {
            $("#followSinaQQ").html('<span><iframe rel="nofollow" width="62" height="22"  ' +
                'frameborder="0" scrolling="no"' +
                'src="http://widget.weibo.com/relationship/followbutton.php?' +
                'language=zh_cn&width=62&height=22&uid=2705801141&style=1&btn=light&dpc=1" ' +
                'style="width:62px;height:22px;border:none;overflow:hidden;  float:left;">' +
                '</iframe></span><span class="spanqq"><iframe rel="nofollow" ' +
                'src="http://open.qzone.qq.com/like?url=http%3A%2F%2Fuser.qzone.qq.com%2F49672282&type=button' +
                '&width=400&height=22&style=2" allowtransparency="true" scrolling="no" border="0" ' +
                'frameborder="0" style="width:62px;height:22px;border:none;overflow:hidden;"></iframe></span>');
        }
    }

    /**
     * 网页头部弹框提示消息
     */
    function Pmessage() {
        if (GLOBAL_VAR.to8to_uid) {
            var f = typeof followTag != 'undefined' ? 1 : 0;
            var c = typeof getMyCollections != 'undefined' ? 1 : 0;
            href = GLOBAL_VAR.server_host + '/api/getRelativeInfo.php?uid=' + GLOBAL_VAR.to8to_uid + '&f=' + f + '&c=' + c + '&t=2&s=' + Math.random(5);

            //在不改变getrelativeInfo.php中的返回的jsonp格式的情况下需要将processFollow变为全局方法，
            //否则需要在返回值中按照seajs的方式来调用
            //例如： seajs.use('common', function(SJB) { SJB.processFollow(2) } )
            window.processFollow = processFollow;

            insertScript('sInsertScript_myfriend', href);
        }
    }

    function processFollow(t) {
        var self = this;
        this.FlickerTime = 0;
        //如果页面有收藏，显示图集
        if (typeof myAllCollections != 'undefined' && $("#myAllCollections").size() > 0) {
            $('#myAllCollections').html(myAllCollections[0]);
        }
        //关注处理
        if (typeof myFriend != 'undefined' && myFriend.length > 0 && typeof($) != 'undefined' && $('.guanzhuA').size() > 0) {
            $('.guanzhuA').each(function() {
                if (in_array($(this).attr('rev'), myFriend)) {
                    if (t == 2) { //专业人士界面
                        $(this).children('span').eq(0).html('已关注');
                        $(this).addClass('hasguanzhuA');
                    } else if (t == 3) { //博客页面
                        $("#guanzhuA").removeClass('follow');
                        $("#guanzhuA").addClass('following');
                        $("#guanzhuA").html('已关注');
                    }
                }
            });
        }
        //顶部的未读消息显示处理
        if (typeof myMessage != 'undefined' && myMessage.length > 0 && myMessage[0] != '') {
            var newMessage = $('#newMessage')[0];
            if (newMessage) {
                newMessage.style.display = 'block';
                $('#messageItem')[0].innerHTML = '<ul>' + myMessage[0] + '<p class="clear"></p></ul><p class="clear"></p>';
            }

            //绑定点击按钮关闭消息
            $('#closeNewMessage').on('click', function() {
                var url = 'http://www.shejiben.com/api/getRelativeInfo.php?closeMess=1';
                if ((window.location.href.indexOf("www.shejiben.com") == -1))
                    url = 'index.php?closeMess=1';
                $.get(url);
                $('#newMessage').remove();
                clearTimeout(self.FlickerTime);
                document.getElementsByTagName('title')[0].innerHTML = GLOBAL_VAR.default_title;
            });

            //有未读消息标题闪烁显示
            if ($('#messageItem') && $('#messageItem').find('li').length > 0) {
                var title_v = document.getElementsByTagName('title')[0].innerHTML;
                var Flicker_title = '【新消息】-' + title_v;
                self.FlickerTime = window.setTimeout(function() {
                    self.ToggleFlickerMessage(title_v, Flicker_title);
                }, 500);
            }
        }
        this.ToggleFlickerMessage = function(title, newtitle) {
            var newtitle = document.getElementsByTagName('title');
            if (typeof newtitle == 'undefined') {
                return false;
            }
            newtitle = newtitle[0].innerHTML;
            self.FlickerTime = window.setTimeout(function() {
                self.ToggleFlickerMessage(newtitle, title);
            }, 500);
        }
    }

    //弹窗自适应居中
    function popup_center(popupObj)
    {

        var windowsWidth = $(window).width();
        var windowsHeight = $(window).height();
        var popupWidth = popupObj.width();
        var popupHeight = popupObj.height();
        var vLeft = (windowsWidth - popupWidth)/2;
        var vTop = (windowsHeight - popupHeight)/2;
        popupObj.css({"left":vLeft,"top":vTop});
    }
    //设计师中心新版上线推送
    function popupNewOnline(){
        $('.popup_mask_sjs').show();
        $('.popup_newonline').show();
        setCookie('to8to_cookie_price_sjs', 1, 90*3600*24*10000,'','.shejiben.com');
        popup_center($(".popup_newonline"));
        $('.popup_newonline .btn_close').click(function(){
            $('.popup_mask_sjs').hide();
            $('.popup_newonline').hide();
            setCookie('to8to_cookie_price_sjs', 1, 90*3600*24*10000,'','.shejiben.com');
        });
    }

    function writeDesignQote() {

        var cookie_price = getCookie('to8to_cookie_price_sjs');
        //区分个人中心：个人中心不用弹广告
        var sjs_url = window.location.href;
        var sjs_url_num = sjs_url.indexOf('?');
        if (sjs_url_num == -1 ) {
            popup_sjs = sjs_url;
        }else{
            popup_sjs = sjs_url.substr(0,sjs_url_num);
        }

        if (
            // document.getElementById('inputPriceDiv') !== null && 
            typeof jQuery === 'function' && 
            GLOBAL_VAR.to8to_ind == 'sjs' && 
            !cookie_price &&
            popup_sjs.indexOf('http://www.shejiben.com/my') == -1
        ) {
//          popupNewOnline();
            /*document.getElementById('inputForm').style.top = ((window.screen.height / 2) - 230) + 'px';
            jQuery.post('http://www.shejiben.com/api/getRelativeInfo.php?writePrice=1', {a:1}, function(data, textStatus, xhr) {
                if (data == 1) {
                    jQuery('#inputPriceDiv').show();
                    setCookie('to8to_cookie_price', 1, 90*3600*24);
                }
            });

            jQuery('#closeBox2').bind('click', function() {
                jQuery('#inputPriceDiv').hide();
                setCookie('to8to_cookie_price', 1, 90*3600*24);
            });

            jQuery('.sbt').bind('click', function() {
                var minPrice = jQuery('#min_price').val(),
                    maxPrice = jQuery('#max_price').val();
                if (!/\d+/.test(minPrice) || !/\d+/.test(maxPrice) || maxPrice <= 0 || minPrice <= 0) {
                    alert('请填写完整相关资料');
                    return false;
                }
                jQuery.post('http://www.shejiben.com/api/getRelativeInfo.php?writePrice=1', {
                    submit:1,
                    min_price : minPrice,
                    max_price : maxPrice
                }, function(data, textStatus, xhr) {
                    if (data == '1') {
                        alert('提交成功');
                        jQuery('#inputPriceDiv').hide();
                    } else {
                        alert('提交失败,请稍后再试');
                        jQuery('#inputPriceDiv').hide();
                    }
                });
            });*/
        }
    }

    function closeActive() {
        $("#new_active").hide();
    }

    function backToTop() {
        $( window ).scrollTop( 0 );
    }

    /**
     * 底部右侧悬浮框相关事件绑定
     */
    function suspensionFrameEvent() {
        var make_jb = $('#make_jb'), 
            new_active = $('#new_active'),
            backTop = $( '#backTop' ),
            addFavoriteBtn = $( '#addF' ),
            Ttime;

        if ( addFavoriteBtn.length ) {
            addFavoriteBtn.bind( 'click', function() {
                addfavorite( 'http://www.shejiben.com' );
            } );
        }

        if ( backTop.length ) {
            backTop.bind( 'click', function() {
                backToTop();
            } );
        }

        if ( make_jb.length )
        {
            make_jb.bind( 'mouseover', function() {
                clearTimeout(Ttime);
                new_active.show();
            }).bind('mouseout', function() {
                Ttime = setTimeout(closeActive,100);
            })
        }
        
        if ( new_active.length )
        {
            new_active.bind( 'mouseover', function() {
                clearTimeout(Ttime);
            }).bind('mouseout', function() {
                Ttime = setTimeout(closeActive,100);
            });
        }
    }

    /**
     * 改变导航位置
     */
    function updateNavigate() {
        var t = document.documentElement.scrollTop; 
        if( t >= 20 ) {
            if ( $( "#sjbNewTop" ).length ) {
                $( "#sjbNewTop" )[0].className = 'sjbNewTop sjbNewTopHide'; 
            } 
            if ( $( "#head_menubar" ).length ) {
                $( "#head_menubar" )[0].className = 'head_menubar head_menubar_scrolling';  
            } 
            if ( $( "#head_content" ).length ) {
                $( "#head_content" )[0].className = "content_width head_content head_rolling"; 
            }
            if ( $( "#backTop" ).length ) {
                $( "#backTop" ).show(); 
            }
        }
    }

    function updateNavigateOnScroll() {
        var t = document.documentElement.scrollTop || document.body.scrollTop,
            v = '',
            v1 = '';
        if ($("#search_val")) {
            v = $("#search_val").val();
        }
        if (t >= 20) {

            if ($("#head_content").length) {
                $("#head_content")[0].className = "content_width head_content head_rolling";
            }

            if ($("#search_val").length) {
                v1 = $("#search_val").val();
                if (v1 == '搜索图片的关键词，如：儿童房') {
                    v1 = $("#search_val").val('搜索图片的关键词');
                }
            }

            if ($("#followus").length) {
                $("#followus").hide();
            }

            if ($("#backTop").length) {
                $("#backTop").show();
            }
        } else {

            if ($("#head_content").length) {
                $("#head_content")[0].className = "content_width head_content ";
            }
            if ($("#search_val").length) {
                v1 = $("#search_val").val();
                if (v1 == '搜索图片的关键词') {
                    v1 = $("#search_val").val('搜索图片的关键词');
                }
            }

            if ($("#followus").length) {
                $("#followus").show();
            }
            if ($("#backTop").length) {
                $("#backTop").hide();
            }
        }

        if (t > 0) {
            if ($("#head_menubar").length) {
                $("#head_menubar")[0].className = 'head_menubar head_menubar_scrolling';
            }
        }else if ( t <= 0 && $('#xwkj_value').length <= 0 ) {
            if ($("#sjbNewTop").length) {
                $("#sjbNewTop")[0].className = 'sjbNewTop';
            }

            if ($("#head_menubar").length) {
                $("#head_menubar")[0].className = 'head_menubar';
            }
        }
        if (v) {
            if (v1) {
                v = v1;
            }

            $("#search_val").blur(function() {
                if ($(this).val() == '') {
                    $(this).val(v);
                }
            });
        }
    }

    /**
     * 初始化网页头部
     */
    function initHeader() {
        billingEvent();
        tencent_sina_status();
        Pmessage();
        blogcheck();
        greet_text();
        searchFormOnFocus();
        searchFormOnBlur();
    }

    function initNewHeader() {

        function removeValue(element){
            var ele_after_val = element.val();
            element.focus(function(){
                $(this).css({'border':'1px solid #f8c7c7',"border-top":"0"});
                if($(this).val() == ele_after_val){
                    $(this).val("");
                }
            });
            element.focusout(function(){
                $(this).css({'border':'1px solid #e6e6e6',"border-top":"0"});
                if($(this).val() == ""){
                    $(this).val(ele_after_val);
                }
            });
        }
        function chioce_pic(element){
            element.click(function(){
                var count= $(this).attr('count');
                if(count==0){
                    $(this).parent().addClass("_pic_click");
                    $(this).attr('count','1');
                }else if(count == 1){
                    $(this).parent().removeClass("_pic_click");
                    $(this).attr('count','0');
                }
            });
        }

        function product_upload(element){
            element.click(function(){
                var msg = check_tpl();
                dialog(msg);
            });
        }
        function dialog (msg){
            $('.dialog_bg').show();
            $('.upload_product_tpl .cont .tpl_msg>label').html(msg);
            $('.upload_product_tpl').show();
        }
        function pic_upload(){
            $('.pict_upload .chioce_pic').click(function(){
                $(this).next().click();
            });
        }
        function dialog_show(ele,show_dialog){
            ele.click(function(){
                $(".dialog_bg").show();
                $(show_dialog).show();
            });
        }
        function close(){
            $(".close").click(function(){
                $('.dialog_bg').hide();
                $(this).parent().parent().hide();
            });
        }

        function check_tpl(){
            // 项目名称
            var pro_name = $('.upload_info .prod_name>input').val();
            var pro_type = $('.upload_info .prod_type>select:eq(0)>option').val();
            var pro_type2 = $('.upload_info .prod_type>select:eq(1)>option').val();
            var pro_type3 = $('.upload_info .prod_type>select:eq(2)>option').val();
            var pro_type4 = $('.upload_info .prod_type>select:eq(3)>option').val();
            var pro_size = $('.upload_info .prod_info>input:eq(0)').val();
            var pro_price = $('.upload_info .prod_info>input:eq(1)').val();
            var msg = "";
            if(pro_name==""){
                msg="请写作品名称";  //        请填写作品名称
            }else if(pro_type==0){
                msg = "请选择空间分类";      //
            }else if(pro_type2 == 0){
                msg = "请选择空间二级分类";
            }else if(pro_type3 == 0){
                msg = "请选择空间三级分类";
            }else if(pro_type4 == 0){
                msg = "请选择风格";
            }else if(pro_size==""){
                msg = "请写项目面积"; // 请填写项目面积
            }else if(pro_price==""){
                msg = "请写项目报价";  //   请填写项目报价
            }
            return msg ;
        }

        function showCitiesNew( city, space, price, area ) {
            var oJsLoader = new SJB.jsLoader();
            oJsLoader.onsuccess = function() {
                editPhotoCat('http://www.shejiben.com/order_lobby/ordershow.php?cityname='+city+
                            '&spaceTag='+space+'&price='+price+'&area='+area, '设计需求', 530, 246);
            };
            oJsLoader.load('http://www.shejiben.com/gb_js/popup.js');
            return false;
        };

        $(function(){
            //头部右侧 导航css 切换 // 鼠标移开时 无边框及背景样式
            var css_={'border-left':'1px #efefef solid','border-right':'1px #efefef solid','background':'none','border-bottom':'none'};
            // 头部右侧 导航css 切换 // 鼠标移上时 有边框及背景样式
            var css_d={'background':'#fff','border-bottom':'1px solid #ddd'};
            // 鼠标移动在登录的li 的时候隐藏掉兄弟节点下的子菜单
            var hea_top_li_one = $(".hea_top_right>ul.tp_node>li:eq(0)");
            //鼠标移上时
            var hea_top_liOver = $(".hea_top_right>ul.tp_node>li.cur");
            // 左侧菜单栏的导航切换样式
            var cont_bann = $('.content_left>div>ul>li');
            // 头部 左侧鼠标移上 显示二维码
            var code_ = $('.hea_top_left ul li.hover');
            // 接单大厅 条件筛选
            var sele_ = $('.selec_ele>div>ul>li');
            //排序筛选
            var des = $('.selec_sort>div>ul>li');
            // 分页
            var st_page = $('.bg_page>ul>li');
            // 其他城市
            var _city = $('#city_py').val(),
                _space = $('#space_py').val(),
                _price = $('#price_range').val();
                _area = $('#area_range').val();
            //var athCity = $('.athCity');
            $('.athCity').bind( 'click', function() {
                //alert(11);
                showCitiesNew( _city, _space, _price,_area );
            } );
            // 删除博文
            var del_blogs=$('.edit').find('span:eq(1)');
            var del = $('.edit').find('a:eq(1)');
            // 关闭博文弹出框
            close();
            // 签到
            var qd_sub = $('.mid').find('input.btn_click');
            // 申请接单 弹出框
            //var sq_dialog = $('._msg_info').find('.apply_for');
            // 接单提醒 弹出框
            var tx_dialog = $('#int_order');//
            // 编辑作品信息
            var edit_info= $('.pict .pic_edit').find("span:eq(0)");
            // 删除作品
            var del_prod = $('.pic_edit .del');
            // 移动图片
            var move_pic = $('.btn_05');
            //新建图集
            var add_pics = $('.my_collect').find('.tal>.pics_add>.btn_06');
            // 收藏图片
            var one_bat = $('._collected>input:eq(0)');
            // 创建新的图集名称
            var add_name = $('.bulid_new .add');
            // 点击清除 val()
            removeValue($('.pic_focus>.describe>textarea'));
            removeValue($('.pic_focus>.describe>input'));
            // 选中图片
            chioce_pic($('.pic_focus>.pic_>i'));

            pic_upload();

            // 取消
            $(".btn_unclick").click(function(){$('.close').click()});

            // 顶部 鼠标滑过
            //return;
            hea_top_liOver.mouseover(function(){
                $(this).find('div:first').show();
                $(this).siblings().find('div').first().hide();

            });

            hea_top_liOver.mouseout(function(){
                $(this).find('div:first').hide();
            });

            $('.infomation_new .leb dl dd').click(function(){
                $(this).addClass('cur').siblings().removeClass('cur');
                if($(this).index() == 2){
                    $(this).parent().parent().prev().attr('class','sx')
                }else{
                    $(this).parent().parent().prev().attr('class','sx_lev');
                }
                var index = $(this).index();
                $(this).parent().parent().siblings('div.tab_info').find('.item:eq('+index+')').show();
                $(this).parent().parent().siblings('.tab_info').find('.item:eq('+index+')').siblings().hide();
            });

            cont_bann.mouseover(function(){
                $(this).addClass('cur').siblings().removeClass('cur');
                $(this).parent().parent().siblings().find('li').removeClass('cur');
            });
            code_.mouseover(function(){
                $(this).find('div').show();
            });
            code_.mouseout(function(){
                $(this).find('div').hide();
            });
            sele_.click(function(){
                $(this).addClass('cur').siblings().removeClass('cur');
            });
            des.click(function(){

                if($(this).index()==4){
                    $(this).unbind('click');
                }else{
                    $(this).addClass('cur').siblings().removeClass('cur');
                }
            });
            //dialog_show(athCity,'.dialog_city');
            dialog_show(del_blogs,'.qd_suc');
            dialog_show(del,'.qd_suc');
            dialog_show($(".add"),'.publish_blong');
            dialog_show(qd_sub,'.qd_dia');
            //dialog_show(sq_dialog,'.sq_dialog');
            dialog_show(tx_dialog,'.or_03');
            dialog_show(edit_info,'.edit_prod_info');
            dialog_show(del_prod,'.edit_prod_del');
            dialog_show(move_pic,'.edit_prod_del');
            dialog_show(add_pics,'.add_picts');
            dialog_show(one_bat,'.collect_pictures');
            click_select('#globalDivClick');
            click_select('#globalDivClick1');

            $('.bottoms>span:eq(1)').click(function(){$(".close").click();});
            //一键收藏  创建图集
            add_name.click(function(){
                $(this).parent().siblings().append('<li>'+$(this).prev().val()+'</li>');
                $(this).parent().prev().find('li').click(function(){
                    $(this).parent().parent().prev().find('label').html($(this).html());
                    $(this).parent().parent().hide();
                });
            });
            product_upload($('.product_btn input'));

            // 私信

            $(".private_cont").find(".letter_list").find('.time>span').click(function(){
                $(this).parent().siblings().toggle();
            });

            // 选择好友

            $('.send_to>.sele_click').click(function(){
                $(this).parent().next().toggle();
            });
            // 关注 .my_vermicelli .vermicelli_cont .vermicelli_list img:hover{}

            $('.vermicelli_list img,.vermicelli_list i').mouseover(function(){
                $(this).parent().find('i').show();
            });
            $(' .vermicelli_list img,.vermicelli_list i').mouseout(function(){
                $(this).parent().find('i').hide();
            });
             //关注 取消关注
             $('.vermicelli_list i').click(function(){
                 var this_stats = $(this).attr('for');
                 if(this_stats==0){
                    $(this).html('已关注');
                    $(this).attr('for','1');
                 }
                 if(this_stats==1){
                     $(this).html('+关注');
                     $(this).attr('for','0');
                 }
             });
        });
        // 点击公用下拉框
        function click_select(globalDivClick){
            $(globalDivClick).click(function(){
                $(this).parent().siblings().find('div.md_options').hide();
                $(this).next().toggle();
                select_atlas($(this).next().find('ul li'),$(this).find('label'),$(this),$(this).next())
            });
        }
        function select_atlas(element,ele,show,hide){

            element.click(function(){
                ele.html($(this).html());
                $(this).parent().parent().hide();
            });
            document_click(show,hide);
        }
        function document_click(show,hide){
            show = show.attr('id');
            document.onclick = function (event)
            {
                var e = event || window.event;
                var elem = e.srcElement||e.target;
                while(elem)
                {
                    if(elem.id == elem || elem.id == show ||elem.id=='bulid_new')
                    {
                        return;
                    }
                    elem = elem.parentNode;
                }
                hide.hide();
            }
        }

    }

    function initFooter() {
        showUserInfo();
        checkCookie();
        writeDesignQote();
        suspensionFrameEvent();
    }

    /**
     * 获取鼠标所在位置坐标
     */
    function mousePosition() {
        var e = event || window.event;
        return {
            x: event.pageX,
            y: event.pageY
        };
    }

    function getScrollTop() {
        return document.documentElement.scrollTop || window.pageYoffset || document.body.scrollTop;
    }

    //记录招标来源2013.11.07 update 2015.08.06
    function checkCookie() {
        var valsource = getCookie( 'sourcepage', 1 );
        var valland = getCookie( 'landpage', 1 );
        var sourcepage = document.referrer;
        var landpage = location.href;
        if( sourcepage!='' ) {
            var domain = sourcepage.split('/');
            if( domain[2] ) {
                domain = domain[2];
            } else {
                domain = sourcepage;
            }
        } else {
            var domain = '';
        }
        //新规则，每次进来如果来源不同，则更新
        if ( !valsource || ( domain.indexOf('shejiben.com') == -1 && valsource != sourcepage ) ) {
            //保存30天，js时间以毫秒为单位需*1000
            setCookie( 'sourcepage', encodeURI(sourcepage), 30*3600000*24, 1, 'shejiben.com' );
        }
        
        if ( !valland || domain.indexOf('shejiben.com') == -1 ) {
            setCookie( 'landpage', encodeURI(landpage), 30*3600000*24, 1, 'shejiben.com' );
        }
    }

    function addfavorite(url, title) {
        try {
            window.external.addFavorite(url, title)
        } catch(e) {
            try {
                window.sidebar.addPanel(title, url, "")
            } catch(e) {
                alert("加入收藏失败，请使用Ctrl+D进行添加")
            }
        }
    };

    function isLogin() {
        return parseInt( GLOBAL_VAR.to8to_uid ) > 0 ? true : false;
    }

    function checkToLogin( setDomain ) {
        if ( !isLogin() ) {
            if ( setDomain === true ) {
                document.domain = 'shejiben.com';
                showSingleLogin( 2, 2 );
            } else {
                showSingleLogin( 1, 2 );
            }
            return false;
        }
        return true;
    }

    /**
     * 发招标
     */
    function publicTender(  ) {

    }

    

    /**
     * 提供可描述输入字段预期值的提示信息（仅限于input，textarea）
     * 该提示会在输入字段为空时显示，并会在字段获得焦点时消失
     * @return void
     */
    
    function placeHolder( params ) {
        var _this = this;
        this.setting = $.extend( true, {
            focusIn: null,
            focusOut: null
        }, params );

        this.defaultCss = 'placeholder-css';
        this.foreach = function() {
            var targets, placeholder, target;
            
            if ( typeof this.setting.trigger === 'object' ) {
                targets = this.setting.trigger.find('input, textarea');
            } else {
                targets = $( 'input, textarea' );
            }
            
            if ( !targets.length ) {
                return false;
            }
            
            targets.each( function( i ) {
                target      = targets.eq(i);
                placeholder = target.attr( 'placeholder' );

                if ( typeof placeholder !== 'undefined' ) {
                    _this.setPlaceHolder( target, placeholder );
                }

            } );
        }

        this.setPlaceHolder = function( target, message ) {

            //默认赋值
            if ( target.val() == '' )
            {
                target.val( message ).addClass( _this.defaultCss );
            }

            //绑定focus事件
            target.bind( 'focus', function() {

                var _val = this.value;

                //如果元素值和初始默认值相等，则赋空值
                if ( _val == message ) {
                    $( this ).val('').removeClass( _this.defaultCss );
                }

                if ( typeof _this.setting.focusIn === 'function' ) {
                    _this.setting.focusIn( this, message );
                }

            } );

            //绑定blur事件
            target.bind( 'blur', function() {

                var _val = this.value;

                //如果元素值为空，则赋初始值
                if ( _val == '' ) {
                    $( this ).val( message ).addClass( _this.defaultCss );
                }

                if ( typeof _this.setting.focusOut === 'function' ) {
                    _this.setting.focusOut( this, message );
                }

            } );
        }

        //检查浏览器是否支持placeholder属性
        this.checkSupport = function() {
            var input = document.createElement( 'input' );
            return "placeholder" in input;
        } 
        
        var isIE = $.support.msie; //IE 1-10版本可以使用
            version = $.support.version;

        //IE 11用jquery判断时候不能使用$.browser.msie, IE11的user-agent中并没有包含msie，需要结合版本号一起判断
        if ( isIE || ( $.support.mozilla && version == '11.0' ) || !this.checkSupport() ) {
            this.foreach();
        }
    }

    var validate = {

        isRequire: function(str) {
            return parseInt(str) <= 0 || str == '' ?　false : true;
        },

        isNumber: function(str) {
            return /^\d+$/.test(str)
        },

        isEmail: function(str) {
            return /^[A-Z_a-z0-9-\.]+@([A-Z_a-z0-9-]+\.)+[a-z0-9A-Z]{2,4}$/.test(str)
        },

        isMobile: function(str) {
            return /^((\(\d{2,3}\))|(\d{3}\-))?((1[345]\d{9})|(18\d{9}))$/.test(str)
        },

        isUrl: function(str) {
            return /^(http:|ftp:|https)\/\/[A-Za-z0-9]+\.[A-Za-z0-9]+[\/=\?%\-&_~`@[\]\':+!]*([^<>\"])*$/.test(str)
        },

        isZip: function(str) {
            return /^[1-9]\d{5}$/.test(str)
        },

        isIp: function(str) {
            return /^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$/.test(str)
        }

    }

    //城市选择（如专业人士频道）
    function showSinglezsjs(spec,workyears,goodlevel,city,sNcity,pageid) {
        var oJsLoader = new jsLoader();
        oJsLoader.onsuccess = function() {
            if (pageid == 'zb')
                editPhotoCat('http://www.shejiben.com/zb/zsjshowsingle.php?type='+spec+'&status='+workyears+'&city='+city+'&pro='+sNcity+'', '设计需求', 463, 216 );
            else
                editPhotoCat('http://www.shejiben.com/zsj/zsjshowsingle.php?spec='+spec+'&workyears='+workyears+'&goodlevel='+goodlevel+'&city='+city+'&sNcity='+sNcity+'', '找设计', 463, 216 );
        };
        oJsLoader.load('http://www.shejiben.com/gb_js/popup.js');
        return false;
    };

    function showCities( city, space, price ) {
        var oJsLoader = new jsLoader();
        oJsLoader.onsuccess = function() {
            editPhotoCat('http://www.shejiben.com/zsj/zsjshowsingle.php?cityname='+city+
                        '&spaceTag='+space+'&price='+price, '设计需求', 520, 260 );
        };
        oJsLoader.load('http://www.shejiben.com/gb_js/popup.js?20160408');
        return false;
    };

    function newverifypic() {
        var A = new Date().getTime();
        if ($('#passport')) {
            $('#passport').attr('src', 'http://www.shejiben.com/passport_sem.php?t=' + A);
        }
    };

jQuery(".pageTag").hover(function() {
    jQuery(this).find('ul').show();
}, function() {
    jQuery(this).find('ul').hide();
});

/*** 模型下载模块公用搜索 ***/
var mxSearch = {
    mxArr: new Array("3","5",'6','4'),
    mxArr_url: new Array({
        '3':[{0:"http://www.shejiben.com/search.php",1:"q",2:"搜索模型",3:"找模型"}],
        '5':[{0:"http://www.shejiben.com/search.php",1:"q",2:"vr材质",3:"找材质"}],
        '6':[{0:"http://www.shejiben.com/search.php",1:"q",2:"cad图块",3:"找cad"}],
        '4':[{0:"http://www.shejiben.com/search.php",1:"q",2:"材质贴图",3:"找贴图"}]
    }),
     //头部的搜索方法
    mxSearchFun: function(mxSearchType){
        var _this = this;
        var html = '';
        jQuery('#mxSearchType').val(mxSearchType);
        jQuery('.select_checked label').html(_this.mxArr_url[0][mxSearchType][0][3]);
        jQuery('.select_type').html('');
        for(var i=0;i < _this.mxArr.length;i++){
            if(_this.mxArr[i] == mxSearchType){
                continue;
            }
            html += '<li onClick="return SJB.mxSearch.mxSearchFun(\''+ _this.mxArr[i] +'\');">'+_this.mxArr_url[0][_this.mxArr[i]][0][3]+'</li>';
        }   
        jQuery('.select_type').append(html);
        jQuery('.select_checked ul').hide();
    }
}

/*** layer的样式重置，主要针对标题以及按钮 ***/
function resetLayerCss(){
    jQuery('.layui-layer-content').css({'height':'auto'});
    if(jQuery('.layui-layer-title')){
        jQuery('.layui-layer-title').css({'background':'#333','color':'#999','font-size':'16px'});  
    }
    if(jQuery('.layui-layer-close')){
        jQuery('.layui-layer-close').css({'background':'url(http://img.shejiben.com/global.png?20160531) -56px -123px','width':'24px','height':'24px','top':'8px','right':'4px'});
    }   
}

    var popLogin = {
        isJsonp:0,
        requestMethod:'POST',
        returnType:'json',
        referrer:'',
        getCodeStatus:0,
        qrcode_id:0,
        init:function(id, n,isJsonp){
            var _this = this;
            _this.isJsonp = isJsonp ? isJsonp : 0;
            if(_this.isJsonp != 0){
                _this.returnType = 'jsonp'; 
                _this.requestMethod = 'GET'; 
            }
            $('body').on('click','.tab_name ul li',function(event){
                if($(event.target).siblings('li').length ==0){
                    return false;
                }
                var index = $(event.target).index();
                $(this).addClass('on').siblings().removeClass('on');
                $('.login_wrap>.tab_content').eq(index).show().siblings().hide();
            });
            $('body').on('click','.login_box .icon_weixin_login',function(event){
                $('.login_account').hide();
                $('.login_weixin').show();
                if($(this).attr('loading') == 0){
                    return false;
                }
                $(this).attr('loading',0);
                _this.getWeixinCode();
            }); 
            $('body').on('click','.login_box .icon_account_login',function(event){
                $('.login_account').show();
                $('.login_weixin').hide();
            }); 
            //刷新二维码
            jQuery('body').on('click','.refresh_code',function(){
                _this.getWeixinCode();
            });
            $('body').on('click','.login_box .icon_account_login',function(event){
                $('.login_account').show();
                $('.login_weixin').hide();
            }); 
            $('body').on('keydown','.tab_content_account form',function (event){
                if (event.keyCode==13) 
                {
                     $('#accountLoginBtn').click();
                }
            });
            $('body').on('keydown','.tab_content_phone form',function (event){
                if (event.keyCode==13) 
                {
                     $('#phoneLoginBtn').click();
                }
            });
            if($('.login_img').length<1 && $('.header_login').length<1){     //登录页不需要加载登录弹窗，只需要绑定时间
                _this.showBox();
            }
            _this.accountLogin();
            _this.phonelogin();
        },
        showBox:function(){
            var _this = this;
            var html='<div class="login_box login_account">'+
                        '<div class="tab_name">'+
                            '<ul>'+
                                '<li class="on">帐号登录</li>'+
                                '<li>短信快捷登录</li>'+
                            '</ul>'+
                            '<span class="icon icon_weixin_login"></span>'+
                        '</div>'+
                        '<div class="login_wrap">'+
                            '<div class="tab_content tab_content_account"  style="display:block;">'+
                                '<form action="#" method="post"  autocomplete="off">'+
                                    '<input type="text" style="display:none;" />'+
                                    '<input type="password" style="display:none;" />'+
                                    '<div class="box box_name">'+
                                        '<input type="text" name="username" id="username" class="inputText" placeholder="请输入用户名/手机/邮箱" autocomplete="off" />'+
                                    '</div>'+
                                    '<div class="box box_passwd">'+
                                        '<input type="password" name="password" id="password" class="inputText" placeholder="请输入您的密码" autocomplete="off"/>'+
                                    '</div>'+
                                    '<div class="box box_auto_login">'+
                                        '<input type="checkbox"/>'+
                                        '<label>下次自动登录</label>'+
                                        '<a href="http://www.shejiben.com/account/login_verify.php" target="_blank">忘记密码？</a>'+
                                    '</div>'+               
                                    '<input type="button" class="btn submit_button" id="accountLoginBtn" value=" 立即登录" />'+
                                    '<input type="hidden" name="referer" id="referer" value="" />'+
                                    '<input type="hidden" name="httpreferer" id="httpreferer" value="" />'+
                                    '<div class="login_dsf">'+
                                        '<a href="http://www.shejiben.com/loginfromqq/oauth/redirect_to_login.php" title="用QQ登录"><span class="icon icon_qq"></span><em>&nbsp;QQ登录</em></a>'+
                                        '<a href="http://www.shejiben.com/loginfromsina/" title="用新浪微博登录"><span class="icon icon_weibo"></span><em>&nbsp;微博登录</em></a>'+
                                        '<a href="http://www.shejiben.com/account/register.php" class="register">免费注册</a>'+
                                    '</div>'+
                                '</form>'+
                            '</div>'+
                            '<div class="tab_content tab_content_phone"  style="display:none;">'+
                                '<form action="#" method="post"  autocomplete="off">'+
                                    '<input type="text" style="display:none;" />'+
                                    '<input type="password" style="display:none;" />'+
                                    '<div class="box box_phone">'+
                                        '<input type="text" name="loginPhone" id="phone" class="inputText" placeholder="请输入手机号" autocomplete="off" value=""/>   '+
                                    '</div>'+
                                    '<div class="box box_code clearfix">'+
                                        '<input type="text" name="phoneCode" id="code" class="inputText" placeholder="请输入您的验证码" autocomplete="off"/>'+
                                        '<input type="button" class="btn_get_code" value="发送动态验证码"></input>'+
                                        '<div class="auth_code" style="display: none;">'+
                                            '<label>'+
                                              '<img src="http://www.shejiben.com/passport_sem.php" width="93" height="24" id="passport" class="passport">'+
                                              '<span class="changeCode"><a href="javascript:void(0)">换一张</a></span>'+
                                            '</label>'+
                                            '<label>'+
                                                '<input type="text" value="" class="authCodeText" id="txt_mathcode" name="txt_mathcode">'+
                                                '<input type="button" class="autoCodeButton" value="确认" id="btn_mathcode">'+
                                            '</label> '+
                                            '<em class="arrow_front"></em>'+
                                            '<em class="arrow_background"></em>'+
                                          '</div>'+
                                    '</div>'+
                                    '<div class="box box_auto_login">'+
                                        '<input type="checkbox"/>'+
                                        '<label>下次自动登录</label>'+
                                        '<a href="http://www.shejiben.com/account/login_verify.php" target="_blank">忘记密码？</a>'+
                                    '</div>'+       
                                    '<input type="button" class="btn submit_button" id="phoneLoginBtn" value=" 立即登录" />'+
                                    '<input type="hidden" name="referer" id="referer" value="" />'+
                                    '<input type="hidden" name="httpreferer" id="httpreferer" value="" />'+
                                    '<div class="login_dsf">'+
                                        '<a href="http://www.shejiben.com/loginfromqq/oauth/redirect_to_login.php" title="用QQ登录"><span class="icon icon_qq"></span><em>&nbsp;QQ登录</em></a>'+
                                        '<a href="http://www.shejiben.com/loginfromsina/" title="用新浪微博登录"><span class="icon icon_weibo"></span><em>&nbsp;微博登录</em></a>'+
                                        '<a href="http://www.shejiben.com/account/register.php" class="register">免费注册</a>'+
                                    '</div>'+
                                '</form>'+
                            '</div>'+
                        '</div>'+
                    '</div>'+
                    '<div class="login_box login_weixin" style="display:none;"> '+
                        '<div class="tab_name tab_name_weixin">'+
                            '<ul>'+
                                '<li>微信登录</li>'+
                            '</ul>'+
                            '<span class="icon icon_account_login"></span>'+
                        '</div>'+
                        '<div class="tab_content tab_content_weixin">'+
                            '<div class="weixin_login_code">'+
                                '<span class="icon_loading"><img src="http://img.shejiben.com/shejiben_img/common/ajax-loader.gif"> </span>'+
                            '</div>'+
                            '<div class="weixin_login_bottom">'+
                                '<span class="tishi">微信扫码 快速登录</span>'+
                                '<div class="help">'+
                                    '<a href="javascript:void(0);">使用帮助</a>'+
                                    '<div class="weixin_login_help">'+
                                        '<img src="http://img.shejiben.com/shejiben_img/login/weixin_login_help.jpg">'+
                                    '</div>'+
                                '</div>'+
                            '</div>'+   
                            '<div class="weixin_login_msg weixin_login_msg_error" style="display:none;">'+
                                '<em class="icon icon_error"></em>'+
                                '<span class="status"><p>二维码失效</p>请点击<a href="javascript:void(0);" class="refresh_code">刷新二维码</a></span>'+
                            '</div>'+
                            '<div class="weixin_login_msg weixin_login_msg_success"  style="display:none;">'+
                                '<em class="icon icon_success"></em>'+
                                '<span class="status"><p>扫描成功</p>请在手机上确认登录</span>'+
                            '</div>'+
                        '</div>'+
                    '</div>';
            // 显示登录弹窗

            require.async('http://static.shejiben.com/common/libs/layer.js?20161010',function(){
                if($('.layui-layer-shade').length <1 && $('.layui-layer').length <1){
                    layer.open({
                        type:1,
                        content:html,
                        area:['340px','380px'],
                        title:'登录',
                        closeBtn:true,
                        btn:0,
                        success:function(){
                        }
                    });
                    placeHolder();
                }
            });
        },
        accountLogin:function(){
            var _this = this;
            jQuery('body').on('click','#accountLoginBtn',function(){
                require.async('http://static.shejiben.com/common/widgets/tool/checkform.js?20161018',function(){
                    var result = $('.tab_content_account').newCheckForm({
                        rules:{
                            username:{                     
                                empty:0,                                        
                                checkType:'text',                                 
                                message: {   
                                    empty:"请输入您的帐号"                    
                                }
                            },
                            password:{                     
                                empty:0,                                        
                                checkType:'text',                               
                                message: {   
                                    empty:"请输入您的密码"                   
                                }
                            }   
                        },
                        returnFlag:false
                    });
                    if(result){
                        require.async('http://stc.shejiben.com/gb_js/md5.js',function(){
                            var username = $('.tab_content_account input[name="username"]').val();
                            var password = $('.tab_content_account input[name="password"]').val();
                                password = $.md5( $.trim(password).toLowerCase());
                            var referer  = $('.tab_content_account input[name="referer"]').val();
                            var httpreferer  = $('.tab_content_account input[name="httpreferer"]').val();
                            $('#accountLoginBtn').attr('disabled','disabled').val('登录中...');
                            $.ajax({
                                url:'http://www.shejiben.com/account/login.php',
                                type: _this.requestMethod,
                                dataType: _this.returnType,
                                data:'username='+username+'&password='+password+'&referer='+referer+'&httpreferer='+httpreferer,
                                success:function(data){
                                    var error = data.error;
                                    if (data.meg == 1 ) {
                                        var html='<div class="msg"><em class="icon icon_error"></em><span>'+data.error+'</span></div>';
                                        $('.tab_content_account .box_passwd').append(html);
                                        $('#accountLoginBtn').removeAttr('disabled').val('立即登录');
                                    }else if (data.meg == 0) {
                                        location.href = data.error;
                                    };
                                }
                            });
                        });
                    }   
                });
            });
        },
        phonelogin:function(){
            var _this = this;
            // 获取图片验证码
            $('body').on('click','.tab_content_phone .btn_get_code',function(){
                if($(this).attr('clicking') == '0'){
                    return false;
                }
                $(this).attr('clicking',0);
                require.async('http://static.shejiben.com/common/widgets/tool/checkform.js?20161018',function(){
                    var resultPhone = $('.tab_content_phone').newCheckForm({
                        rules:{
                            loginPhone:{                     
                                empty:0,                                        
                                checkType:'text', 
                                regType:[1],  
                                message: {   
                                    empty:"请输入您的手机号码" ,
                                    regType:"请输入正确的手机号码"                   
                                }
                            }       
                        },
                        returnFlag:false
                    });
                    if(resultPhone){
                        $('.tab_content_phone .auth_code').show();
                    }
                    else{
                        $('.tab_content_phone .btn_get_code').attr('clicking',1);
                    }
                }); 
            });
            // 更换图片验证码
            $('body').on('click','.tab_content_phone .changeCode a',function(){
                var A = new Date().getTime();
                if ($('.tab_content_phone #passport')) {
                    $('.tab_content_phone #passport').attr('src', 'http://www.shejiben.com/passport_sem.php?t=' + A);
                }
            });
            //验证图片验证码
            var countDownResult  = 0;
            $('body').on('click','#btn_mathcode',function(){
                if($(this).attr('clicking') == '0'){
                    return false;
                }
                $(this).attr('clicking',0);
                clearInterval(countDownResult);
                $('.tab_content_phone .msg').remove();
                var picCode = $('.tab_content_phone input[name="txt_mathcode"]');
                if($.trim(picCode.val()) == ''){
                    picCode.focus();
                    $('#btn_mathcode').attr('clicking',1);
                }
                else{
                    // 获取手机验证码
                    var phone = $('.tab_content_phone input[name="loginPhone"]');
                    var mathCode = $('.tab_content_phone input[name="txt_mathcode"]');
                    var times = 100;
                    $.ajax({
                        url:'http://www.shejiben.com/account/loginPublic.php',
                        type: _this.requestMethod,
                        dataType: _this.returnType,
                        data:'type=reg&mobile='+phone.val()+'&cCode='+mathCode.val(),
                        success:function (data){
                            if(data.errCode == 0 ){
                                $('.btn_get_code').val('获取中...');
                                mathCode.val('');
                                $('.tab_content_phone .auth_code').hide();
                                countDownResult = setInterval(function(){
                                    if(times > 0){
                                        $('.btn_get_code').val('重新获取('+times+')');
                                        times=times-1;
                                    }
                                    else{
                                        $('#btn_mathcode').attr('clicking',1);
                                        $('.btn_get_code').attr('clicking',1);
                                        $('.btn_get_code').val('发送动态验证码');
                                        clearInterval(countDownResult);
                                        times = 100;
                                    }
                                },1000);
                            }
                            else if(data.errCode == 1002 ){    // 账号不存在
                                $('#btn_mathcode').attr('clicking',1);
                                var html='<div class="msg"><em class="icon icon_error"></em><span>'+data.errMsg+'</span></div>';
                                $('.tab_content_phone .box_code').append(html);
                            }
                            else if(data.errCode == 1035){    //请求次数已达上限
                                $('#btn_mathcode').attr('clicking',1);
                                var html='<div class="msg"><em class="icon icon_error"></em><span>'+data.errMsg+'</span></div>';
                                $('.tab_content_phone .box_code').append(html);
                            }
                            else if(data.errCode == 4101 ){    // 手机号为空
                                $('#btn_mathcode').attr('clicking',1);
                                alert(data.errMsg);
                            }
                            else if(data.errCode == 4102 ){    // 手机号不合法
                                $('#btn_mathcode').attr('clicking',1);
                                alert(data.errMsg);
                            }
                            else if(data.errCode == 4104 ){    // 图片验证码错误
                                $('#btn_mathcode').attr('clicking',1);
                                alert(data.errMsg);
                            }
                            else if(data.errCode == 500 ){    //操作失败
                                $('#btn_mathcode').attr('clicking',1);
                                alert(data.errMsg);

                            }
                        },
                        error:function (){
                            $('#btn_mathcode').attr('clicking',1);
                            alert('获取手机验证码失败，请重试。');
                        }
                    });
                }
            });
            jQuery('body').on('click','#phoneLoginBtn',function(){
                require.async('http://static.shejiben.com/common/widgets/tool/checkform.js?20161018',function(){
                    var result = $('.tab_content_phone').newCheckForm({
                        rules:{
                            loginPhone:{                     
                                empty:0,                                        
                                checkType:'text', 
                                regType:[1],  
                                message: {   
                                    empty:"请输入您的手机号码" ,
                                    regType:"请输入正确的手机号码"                   
                                }
                            },  
                            phoneCode:{                     
                                empty:0,                                        
                                checkType:'text', 
                                regType:[0],                               
                                message: {   
                                    empty:"请输入验证码",
                                    regType:"请输入正确的验证码"                     
                                }
                            }   
                        },
                        returnFlag:false
                    });
                    if(result){
                        $('.tab_content_phone .msg').remove();
                        $('#phoneLoginBtn').val('登录中...').attr('disabled','disabled');
                        var phone = $('.tab_content_phone input[name="loginPhone"]');
                        var phoneCode = $('.tab_content_phone input[name="phoneCode"]');
                        var referer  = $('.tab_content_account input[name="referer"]').val();
                        var httpreferer  = $('.tab_content_account input[name="httpreferer"]').val();
                        $.ajax({
                            url:'http://www.shejiben.com/account/loginPublic.php',
                            type: _this.requestMethod,
                            dataType: _this.returnType,
                            data:'type=login&mobile='+phone.val()+'&smsCode='+phoneCode.val()+'&referer='+referer+'&httpreferer='+httpreferer,
                            success:function (result){
                                if(result.errCode == 0 ){
                                    window.location.href=result.data.referer;
                                }
                                else if(result.errCode == 1002 ){   //账号不存在
                                    $('#phoneLoginBtn').removeAttr('disabled').val('立即登录');
                                    var html='<div class="msg"><em class="icon icon_error"></em><span>'+result.errMsg+'</span></div>';
                                    $('.tab_content_phone .box_code').append(html);
                                }
                                else if(result.errCode == 1035){   //   请求次数已达上限
                                    $('#phoneLoginBtn').removeAttr('disabled').val('立即登录');
                                    var html='<div class="msg"><em class="icon icon_error"></em><span>'+result.errMsg+'</span></div>';
                                    $('.tab_content_phone .box_code').append(html);
                                }
                                else if(result.errCode == 4101 ){   // 手机号不合法
                                    $('#phoneLoginBtn').removeAttr('disabled').val('立即登录');
                                    var html='<div class="msg"><em class="icon icon_error"></em><span>'+result.errMsg+'</span></div>';
                                    $('.tab_content_phone .box_code').append(html);
                                }
                                else if(result.errCode == 4102 ){    // 手机号为空
                                    $('#phoneLoginBtn').removeAttr('disabled').val('立即登录');
                                    var html='<div class="msg"><em class="icon icon_error"></em><span>'+result.errMsg+'</span></div>';
                                    $('.tab_content_phone .box_code').append(html);
                                }
                                else if(result.errCode == 4104 ){    // 验证码错误
                                    $('#phoneLoginBtn').removeAttr('disabled').val('立即登录');
                                    var html='<div class="msg"><em class="icon icon_error"></em><span>'+result.errMsg+'</span></div>';
                                    $('.tab_content_phone .box_code').append(html);
                                }
                                else if(result.errCode == 500 ){
                                    $('#phoneLoginBtn').removeAttr('disabled').val('立即登录');
                                    alert('操作失败');

                                }
                            },
                            error:function (){
                                alert('登录失败，请重试。');
                            }
                        });
                    }
                });
            });
        },
        getWeixinCode:function(){
            var _this = this;
            jQuery.ajax({
                async: true,
                type: _this.requestMethod,
                dataType: _this.returnType,
                url: 'http://www.shejiben.com/weixin/run.php',
                data: {action: 'createQrcode'},
                success: function (res) {
                    if (res.errCode == 0) {
                        var heaimg = new Image();
                        heaimg.src = res.imageUrl;
                        heaimg.onload = function () {
                            var img = '<span class="icon_code"><img src='+res.imageUrl+'><em class="icon_logo"></em></span>';
                            $('.weixin_login_code').html('');
                            $(".weixin_login_code").append(img);
                        }
                        _this.qrcodeSession(res.sceneId);
                        $(".weixin_login_msg").hide();
                        $(".weixin_login_bottom").show();
                        getCodeStatus = 1;
                        $('.login_box .icon_weixin_login').attr('clicking',1);
                        // 二维码获取成功后轮询扫描状态
                        _this.getmxStatus(res.sceneId);
                    }
                    else if(res.errCode == 1){
                        $('.login_box .icon_weixin_login').attr('clicking',1);
                        alert('二维码获取失败，请重试');
                    }
                },
                error:function(){
                    alert('请求失败，请重试');
                }
            });
        },
        getmxStatus:function(sceneId){
            var _this = this; 
            jQuery.ajax({
                type: _this.requestMethod,
                dataType: _this.returnType,
                url: 'http://www.shejiben.com/weixin/run.php',
                data: {action: 'getScanState',sceneId: sceneId},
                timeout: 5000, 
                success: function (data) {
                    if (data.errCode == "0") {
                        $(".weixin_login_msg_success").show();
                        $(".weixin_login_msg_error").hide();
                        $(".weixin_login_bottom").hide();
                        var res = data;
                       var referer = $('#referer').val();
                        window.location.href = 'http://www.shejiben.com/weixin/callback.php?referer=' + referer + '&sceneId=' + res.user.qid + '&nickName=' + res.user.nickname + '&headImgUrl=' + res.user.headimgurl + '&openId=' + res.user.openid + '&unionId=' + res.user.unionid;
                    }
                    if (data.code == '404') {
                        getCodeStatus = getCodeStatus + 1;
                        if (getCodeStatus > 39) {
                            $(".weixin_login_msg_success").hide();
                            $(".weixin_login_msg_error").show();
                            $(".weixin_login_bottom").hide();
                        } 
                        else {
                            _this.getmxStatus(sceneId);
                        }
                    }
                },
                error: function () {
                    getCodeStatus = getCodeStatus + 1;
                    if (getCodeStatus > 39) {
                        $(".weixin_login_msg_success").hide();
                        $(".weixin_login_msg_error").show();
                        $(".weixin_login_bottom").hide();
                    } 
                    else {
                        _this.getmxStatus(sceneId);
                    }     
                }
            });
        },
        qrcodeSession:function(sceneId) {
            var _this = this;
            $.ajax({
                async: true,
                type: 'GET',
                dataType:'jsonp',
                url: "http://www.shejiben.com/account/login.php",
                data: {action: 'addQrcodeSession', sceneId: sceneId},
                success : function(){}
            });
        }
    }
    // 招标成功后的提示信息，兼容老的招标方法，招标优化后删掉
    function zbSuccessMsg(){
        var str = '<div class="pop_overlay"></div>'+
                    '<div class="common_zb_success_msg" id="common_zb_success_msg">'+
                        '<div class="column_name"><p class="name">申请成功</p><span class="btn_close"></span></div>'+
                        '<div class="submit_status">'+
                            '<span class="icon icon_sucess icon_sucess_new_sub_zb"></span>'+
                            '<p class="tips_b">申请成功</p>'+
                            '<p class="tips_s">为详细了解您的设计需求</p><p class="tips_s">设计本客服会在24小时内电话联系您</p>'+
                        '</div>'+
                        '<div class="app_tips">'+
                            '<i class="icon_app_zb"></i>'+
                            '<p>下载设计本APP</p><p>随时了解需求进度</p>'+
                        '</div>'+
                    '</div>';
        $('body').append(str); 
        $('.common_zb_success_msg .btn_close ,.common_zb_success_msg .btn_ok').on('click',function(){
            $('.common_zb_success_msg ,.pop_overlay').remove();
        });
    }
    function getUrlParam(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);  //匹配目标参数
        if (r != null) return unescape(r[2]); return null; //返回参数值
    }
    //导出外部需要调用的模块,不需要外部调用的不需要导出,
    //并将main.js中的方法暴露出来,供全局使用
    window.SJB = module.exports = {
        GLOBAL_VAR: GLOBAL_VAR,
        getBrowser: getBrowser,
        setCookie: setCookie,
        getCookie: getCookie,
        //autoSize: autoSize,
        //autoSize_w: autoSize_w,
        //autoSize_H: autoSize_H,
        //in_array: in_array,
        //insertScript: insertScript,
        //jsLoader: jsLoader,
        //showSingleLogin: showSingleLogin,
        //isDigit: isDigit,
        showUserInfo: showUserInfo,
        //free_yuyue: free_yuyue,
        checkSearchForm: checkSearchForm,
        searchFun: searchFun,
        //cutstr: cutstr,
        initHeader: initHeader,
        searchBannerEvent: searchBannerEvent,
        //processFollow: processFollow,
        //mousePosition: mousePosition,
        //getScrollTop: getScrollTop,
        initFooter: initFooter,
        updateNavigateOnScroll: updateNavigateOnScroll,
        updateNavigate: updateNavigate,
        //isLogin: isLogin,
        //checkToLogin: checkToLogin,
        // invite: invite,
        //AddFollowNew: AddFollowNew,
        placeHolder: placeHolder,
        //validate: validate,
        //showSinglezsjs: showSinglezsjs,
        //newshowSingleLogin: newshowSingleLogin,
        //showCities: showCities,
        newverifypic: newverifypic,
        initNewHeader:initNewHeader,
        backToTop:backToTop,
        //commonBottomZb:commonBottomZb,
        zbSuccessMsg:zbSuccessMsg,
        //commonSubToolBar:commonSubToolBar,
        //subZbForm:subZbForm,
        //initColorboxCss:initColorboxCss,
        //ActionCollection:ActionCollection,
        //ActionAsk:ActionAsk,
        //ShowSuccessMsg:ShowSuccessMsg,
        //mxSearch:mxSearch,
        //qqWeiboShare:qqWeiboShare,
        resetLayerCss:resetLayerCss,
        popLogin:popLogin,    // 主要为了兼容收藏弹窗做的过渡，涉及到弹窗的模块优化完毕后去掉
        getUrlParam:getUrlParam

    }
});
