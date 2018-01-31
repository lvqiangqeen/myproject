seajs.config({
    paths: {
        'base'      : 'http://static.shejiben.com',
        'widget'    : 'http://static.shejiben.com/widget',
        'lib'       : 'http://static.shejiben.com/lib',
        'common'    : 'http://static.shejiben.com/common',
        'sjsCenter' : 'http://static.shejiben.com/sjsCenter'
    },
    alias: {
        'jquery'            : 'common/libs/jquery.js?20160707',
        'swiper'            : 'common/widgets/tool/idangerous.swiper.min.js?20160808',
        'layer'             : 'common/libs/layer.js?20170816',
        'common'            : 'common/statics/common.js?20171019',
        'rsa'               : 'common/libs/rsas.js?20170816',
        'provinces'         : 'common/widgets/tool/GlobalProvinces.js?20170816',
        'provinceSelect'    : 'common/widgets/tool/GlobalProvinceSelect.js',
        'url'               : 'common/widgets/tool/url.js?20160811',
        'lazyload'          : 'common/widgets/tool/lazyload.js?20160103',
        'switchtab'         : 'common/widgets/tool/switchtab.js?20160815',
        'checkform'         : 'common/widgets/tool/checkform.js?20171124',
        'yuyue'             :'common/widgets/ui/yuyue.js?20170816',
        'ask'               :'common/widgets/ui/ask.js?20170419',
        'collection'        :'common/widgets/ui/collection.js?20170816',
        'bottomZb'          :'common/widgets/ui/bottom_zb.js?20171124',
        'login'             :'http://static.shejiben.com/login/login.js?20170816',
        'subZb'             :'common/widgets/ui/sub_zb.js?20171125',
        'popZb'             :'common/widgets/ui/popZb.js?20170822'
    },
    preload : ['jquery', 'common']  //预加载jquery和common.js
});