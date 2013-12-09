<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EasyCMS.Manage.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Css/easyuithemes/icon.css" rel="stylesheet" />
    <link href="../Css/easyuithemes/bootstrap/easyui.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.1.10.2.js"></script>
    <script src="../Scripts/jquery.easyui.min.js"></script>
    <style type="text/css">

    </style>
    <script type="text/javascript">
        var DemoMenu = [
            {
                Text:"内容管理",
                ChildMenu: [
                {
                    Text: "内容管理",
                    Url:"www.baidu.com"
                }, {
                    Text: "用户管理",
                    Url:"www.163.com"
                }, {
                    Text: "我的信息",
                    Url:"www.126.com"
                }]
            },
            {
                Text: "用户管理",
                ChildMenu: [
                    {
                        Text: "内容管理",
                        Url:"www.baidu.com"
                    }, {
                        Text: "用户管理",
                        Url:"www.163.com"
                    }, {
                        Text: "我的信息",
                        Url:"www.126.com"
                    }]
            },
            {
                Text: "我的信息",
                ChildMenu: [
                    {
                        Text: "内容管理",
                        Url:"www.baidu.com"
                    }, {
                        Text: "用户管理",
                        Url:"www.163.com"
                    }, {
                        Text: "我的信息",
                        Url:"www.126.com"
                    }]
            }
        ];
        $(document).ready(function () {
            $("#DivDateTime").html("今天是："+(new Date()).toDateString()+"   当前时间："+(new Date()).toTimeString());
            LoadMenu();
        })
        function LoadMenu() {
            $.each(DemoMenu, function (index, item) {
                var innerhtml = '';
                $.each(item.ChildMenu, function (indexchild,itemchild) {
                    innerhtml+="<button >" + itemchild.Text + "</button><br/>";
                });
                $('#DivMenuBar').accordion('add', {
                    title: item.Text,
                    content: innerhtml,
                    selected: false
                });
            });
        }
    </script>


</head>
<body class="easyui-layout">
    <div data-options="region:'north'" style="height:100px">
    </div>
    <div data-options="region:'south',split:true" style="height:50px;">
        <div id="DivDateTime" style="float:right"></div>
    </div>
    <div id="DivMenuBar" class="easyui-accordion" data-options="region:'west',split:true" title="West" style="width:200px;min-height:350px">
    </div>
    <div data-options="region:'center',iconCls:'icon-ok'" title="Center">

    </div>

    
</body>
</html>
