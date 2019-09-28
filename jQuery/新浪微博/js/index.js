$(function () {
    //0监听内容的实时输入,添加委托
    $('body').delegate('.comment','propertychange input',function () {
        //判断是否输入了内容
        if($(this).val().length>0){
            //让按钮可用
            $('.send').prop('disabled',false);
        }else{
            //让按钮不可用
            $('.send').prop('disabled',true);
        }
    });
   //1监听发布按钮
    $('.send').click(function () {
        //拿到用户输入的内容
        let $text = $('.comment').val();
        //根据内容创建节点
        let $weibo = createEle($text);
        //插入微博
        $('.messageList').prepend($weibo);
        $('.comment').val('');
    });

    $('body').delegate('.infoDel','click',function () {
        $(this).parents('.info').remove();
    });
    //创建节点的方法
    function createEle(text){
        let $weibo = $('<div class="info">\n' +
            '            <p class="infoText">'+text+'</p>\n' +
            '            <p class="infoOperation">\n' +
            '                <span class="infoTime">'+formartDate()+'</span>\n' +
            '                <span class="infoHandle">\n' +
            '                    <a href="javascript:;">0</a>\n' +
            '                    <a href="javascript:;">0</a>\n' +
            '                    <a href="javascript:;" class="infoDel">删除</a>\n' +
            '                </span>\n' +
            '            </p>\n' +
            '        </div>');
        return $weibo;
    }
    //生成时间的方法
    function formartDate(){
        let date = new Date();
        let arr = [date.getFullYear() + '-',
            date.getMonth() +1 +'-',
            date.getDate() +' ',
            date.getHours() + ':',
            date.getMinutes() + ':',
            date.getSeconds()
        ];
        return arr.join('');
    }
});