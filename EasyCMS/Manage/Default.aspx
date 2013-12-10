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
        .MenuBtn{
            width:100%;
            margin:0px 0px;
            text-align:center;
        }
        #DivMenuBar .panel-title{
            text-align:center;
        }
    </style>
    <script type="text/javascript">
        var DemoMenu = [
            {
                Text:"测试功能",
                ChildMenu: [
                {
                    Text: "添加tabs",
                    Url:"http://www.baidu.com"
                }, {
                    Text: "用户管理",
                    Url:"http://www.163.com"
                }, {
                    Text: "我的信息",
                    Url:"http://www.126.com"
                }]
            },
            {
                Text: "用户管理",
                ChildMenu: [
                    {
                        Text: "内容管理",
                        Url:"http://www.baidu.com"
                    }, {
                        Text: "用户管理",
                        Url:"http://www.163.com"
                    }, {
                        Text: "我的信息",
                        Url:"http://www.126.com"
                    }]
            },
            {
                Text: "我的信息",
                ChildMenu: [
                    {
                        Text: "内容管理",
                        Url:"http://www.baidu.com"
                    }, {
                        Text: "用户管理",
                        Url:"http://www.163.com"
                    }, {
                        Text: "我的信息",
                        Url:"http://www.126.com"
                    }]
            }
        ];
        $(document).ready(function () {
            updateDateTime();
            $("#DivRegion").tabs({
                border: false,
                onSelect: function (title) {
                    console.info(title+" tab was selected")
                }
            });
            LoadMenu();
            $('#DivRegion').tabs('add', {
                title: '主页',
                content: 'Tab Body',
                closable: false,
                tools: [{
                    iconCls: 'icon-mini-refresh',
                    handler: function () {
                        alert('refresh');
                    }
                }]
            });
        })
        function LoadMenu() {
            $.each(DemoMenu, function (index, item) {
                var innerhtml = '';
                $.each(item.ChildMenu, function (indexchild,itemchild) {
                    innerhtml+="<button class='MenuBtn' onclick='AddTabes(this)' title='"+itemchild.Url+"'>" + itemchild.Text + "</button><br/>";
                });
                $('#DivMenuBar').accordion('add', {
                    title: item.Text,
                    content: innerhtml,
                    selected: false
                });
            });
        }
        function AddTabes(item) {
            var $item=$(item);
            var $ExistTab = null;
            $.each($("#DivRegion").tabs("tabs"), function (index, it) {
                console.warn($(it).panel("options").title);
                console.warn($item.html());
                if ($(it).panel("options").title == $item.html()) {
                    $ExistTab = $(it);
                    console.warn($ExistTab.panel("options").title);
                }
            })
            if ($ExistTab==null) {
                $('#DivRegion').tabs('add', {
                    title: $item.html(),
                    content: "<iframe id='" + $item.html() + "' src='" + $item.attr('title') + "' style='width:98%;height:95%'></iframe>",
                    closable: true,
                    collapsible: false,
                    tools: [{
                        iconCls: 'icon-mini-refresh',
                        handler: function () {
                            $("#" + $item.html()).attr("src",$("#" + $item.html()).attr("src"));
                        }
                    }]
                });
            } else {
                console.warn($ExistTab.panel("options").title);
                console.warn($ExistTab);
                $("#DivRegion").tabs("select", $ExistTab.panel("options").title);
            }
        }
        function updateDateTime() {
            $("#DivDateTime").html("今天是：" + (new Date()).toDateString() + "   当前时间：" + (new Date()).toTimeString());
            setTimeout(updateDateTime, 500);
        }
    </script>


</head>
<body class="easyui-layout" style="text-align:center">
    <div data-options="region:'north'" style="height:100px">
    </div>
    <div data-options="region:'south'" style="height:50px;">
        <div id="DivDateTime" style="float:right"></div>
    </div>
    <div id="DivMenuBar" class="easyui-accordion" data-options="region:'west',split:true" title="管理员" style="width:200px;min-height:350px">
    </div>
    <div id="DivRegion" data-options="region:'center',collapsible:'false'">

    </div>

    
</body>
</html>
