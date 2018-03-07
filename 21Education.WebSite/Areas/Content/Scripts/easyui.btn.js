
//ifram 返回
function frameReturnByClose() {
    $("#modalwindow").window('close');
}
//iframe 返回并刷新
function frameReturnByReload(flag) {
    if (flag)
        $("#List").datagrid('load');
    else
        $("#List").datagrid('reload');
}
//输出信息
function frameReturnByMes(mes) {
    $.messageBox5s('提示', mes);
}
$(function () {
    var path = $("#path[type=hidden]").val();
    $("#btnCreate").click(function () {
        $("#modalwindow").html("<iframe width='100%' height='98%' scrolling='yes' frameborder='0'' src='" + path + "/Create'></iframe>");
        $("#modalwindow").window({ title: '新增', width: 800, height: 400, iconCls: 'icon-add' }).window('open');
    });
    $("#btnEdit").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $("#modalwindow").html("<iframe width='100%' height='99%' scrolling='yes' frameborder='0' src='" + path + "/Edit?Id=" + row.Id + "'></iframe>");
            $("#modalwindow").window({ title: '编辑', width: 780, height: 430, iconCls: 'icon-edit' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的记录'); }
    });
    $("#btnDetails").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {

            $("#modalwindow").html("<iframe width='100%' height='98%' scrolling='no' frameborder='0' src='" + path + "/Details?n=" + row.Id + "&Ieguid=" + GetGuid() + "'></iframe>");
            $("#modalwindow").window({ title: '详细', width: 500, height: 300, iconCls: 'icon-details' }).window('open');
        } else { $.messageBox5s('提示', '请选择要操作的记录'); }
    });
    $("#btnQuery").click(function () {
        var queryStr = $("#txtQuery").val();
        //如果查询条件为空默认查询全部
        if (queryStr == null) {
            $('#List').datagrid({
                url: path + '/GetList'
            });
        }
        $('#List').datagrid({
            url: path + '/GetList?queryStr=' + encodeURI(queryStr)
        });

    });
    $("#btnDelete").click(function () {
        var row = $('#List').datagrid('getSelected');
        if (row != null) {
            $.messager.confirm('提示', '确定删除', function (r) {
                if (r) {
                    $.post(path + "/Delete?Id=" + row.Id, function (data) {
                        if (data.type == 1)
                            $("#List").datagrid('reload');
                        $.messageBox5s('提示', data.message);
                    }, "json");

                }
            });
        } else { $.messageBox5s('提示', '请选择要操作的记录'); }
    });
    $("#btnReload").click(function () {
        frameReturnByReload(false);
    });
});
