layui.use(['form', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;
    //第一个实例
    table.render({
        elem: '#menuList'
        , height: 500
        , url: '/Menu/GetManagerMenu' //数据接口
        , page: true //开启分页
        , cols: [[ //表头
            { type: "checkbox", fixed: "left", width: 50 },
            { field: 'MenuID', title: '菜单ID', width: 80, sort: true, fixed: 'left' }
            , { field: 'MenuName', title: '菜单名称', width: 200 }
            , { field: 'PID', title: '上级菜单ID', width: 200, sort: true }
            , { field: 'ShowName', title: '显示名称', width: 290 }
            , { field: 'ImgUrl', title: '菜单图片', width: 325 }
            , { field: 'LinkUrl', title: '菜单链接', width: 350, sort: true }
            , { field: 'OrderBy', title: '排序号', width: 80, sort: true }
            , { field: 'UpdateTIME', title: '修改时间', width: 200 }
            ,{ title: '操作', minWidth: 120, templet: '#menuListBar', fixed: "right", align: "center" }
        ]]
    });

    //搜索【此功能需要后台配合，所以暂时没有动态效果演示】
    $(".search_btn").on("click", function () {
        if ($(".searchVal").val() !== '') {
            table.reload("menuList", {
                page: {
                    curr: 1 //重新从第 1 页开始
                },
                where: {
                    Key: $(".searchVal").val()  //搜索的关键字
                }
            });
        } else {
            layer.msg("请输入搜索的内容");
        }
    });

    //添加用户
    function addMenu(edit) {
        var tit = "添加菜单";
        if (edit) {
            tit = "编辑菜单";
        }
        var index = layui.layer.open({
            title: tit,
            type: 2,
            anim: 1,
            area: ['600px', '80%'],
            content: "/Menu/AddOrModify/",
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find("#MenuID").val(edit.MenuID);
                    body.find(".MenuName").val(edit.MenuName);
                    body.find(".ShowName").val(edit.ShowName);
                    body.find(".ImgUrl").val(edit.ImgUrl);
                    body.find(".LinkUrl").val(edit.LinkUrl);
                    body.find(".OrderBy").val(edit.OrderBy);
                    body.find(".ShowName").val(edit.ShowName);
                    body.find(".PID").val(edit.PID);
                    body.find(".Remark").text(edit.Remark);    //角色备注
                    form.render();

                }
            }
        });
    }

    //批量删除
    $(".delAll_btn").click(function () {
        var checkStatus = table.checkStatus('menuList'),
            data = checkStatus.data,
            roleId = [];
        if (data.length > 0) {
            for (var i in data) {
                roleId.push(data[i].MenuID);
            }
            layer.confirm('确定删除选中的菜单？', { icon: 3, title: '提示信息' }, function (index) {
                //获取防伪标记
                del(roleId);
            });
        } else {
            layer.msg("请选择需要删除的菜单");
        }
    });

    //列表操作
    table.on('tool(menuList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            addMenu(data);
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此菜单？', { icon: 3, title: '提示信息' }, function (index) {
                del(data.MenuID);
            });
        }
    });

    function del(menuId) {
        $.ajax({
            type: 'POST',
            url: '/Menu/Delete/',
            data: { menuId: menuId },
            dataType: "json",
            headers: {
                "X-CSRF-TOKEN-xuqiuping": $("input[name='AntiforgeryKey_xuqiuping']").val()
            },
            success: function (data) {//res为相应体,function为回调函数
                layer.msg(data.ResultMsg, {
                    time: 2000 //20s后自动关闭
                }, function () {
                    tableIns.reload();
                    layer.close(index);
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                layer.alert('操作失败！！！' + XMLHttpRequest.status + "|" + XMLHttpRequest.readyState + "|" + textStatus, { icon: 5 });
            }
        });
    }


    $(".addMenu_btn").click(function () {
        addMenu();
    });


});