layui.use(['form', 'layer'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on("submit(addUser)", function (data) {
        //弹出loading
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        // 实际使用时的提交信息
        $.post("/Manager/AddOrModify", {
            MID: $("#MID").val(),
            LoginName: $(".LoginName").val(),  //登录名
            Password: $(".Password").val(),
            UserName: $(".UserName").val(),
            HeadImg: $(".HeadImg").val(),
            Mobile: $(".Mobile").val(),
            RoleID: data.field.RoleId,  //会员等级
            Email: $(".Email").val(),  //邮箱
            IsLock: data.field.IsLock,    //用户状态
            Remark: $(".Remark").text()    //用户简介
        }, function (res) {
            if (res.ResultCode === 0) {
                var alertIndex = layer.alert(res.ResultMsg, { icon: 1 }, function () {
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                    top.layer.close(alertIndex);
                });
                //$("#res").click();//调用重置按钮将表单数据清空
            } else if (res.ResultCode === 102) {
                layer.alert(res.ResultMsg, { icon: 5 }, function () {
                    layer.closeAll("iframe");
                    //刷新父页面
                    parent.location.reload();
                    top.layer.close(alertIndex);
                });
            }
            else {
                layer.alert(res.ResultMsg, { icon: 5 });
            }
        });
        setTimeout(function () {
            top.layer.close(index);
            top.layer.msg("用户添加成功！");
            layer.closeAll("iframe");
            //刷新父页面
            parent.location.reload();
        }, 2000);
        return false;
    })

    //格式化时间
    function filterTime(val) {
        if (val < 10) {
            return "0" + val;
        } else {
            return val;
        }
    }
    //定时发布
    var time = new Date();
    var submitTime = time.getFullYear() + '-' + filterTime(time.getMonth() + 1) + '-' + filterTime(time.getDate()) + ' ' + filterTime(time.getHours()) + ':' + filterTime(time.getMinutes()) + ':' + filterTime(time.getSeconds());

})