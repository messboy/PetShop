<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationControl.ascx.cs" Inherits="PetShop.Web.NavigationControl" %>
<%@ OutputCache Duration="100000" VaryByParam="*" %>

<script src="../Scripts/jquery-2.1.1.js"></script>
<script src="../Scripts/bootstrap.js"></script>
<%--<link href="../Content/bootstrap.css" rel="stylesheet" />--%>

<style type="text/css">
    .tree {
        width: 150px;
        min-height: 20px;
        padding: 19px;
        margin-bottom: 20px;
        background-color: #E3E5DC;
        /*border:1px solid #999;*/
        -webkit-border-radius: 4px;
        -moz-border-radius: 4px;
        border-radius: 4px;
        -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.05);
        -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.05);
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.05);
    }

        .tree li {
            list-style-type: none;
            margin: 0;
            padding: 5px 5px 0 5px;
            position: relative;
        }

            .tree li::before, .tree li::after {
                content: '';
                left: -20px;
                position: absolute;
                right: auto;
            }

            .tree li::before {
                border-left: 1px solid #999;
                bottom: 50px;
                height: 100%;
                top: 0;
                width: 1px;
            }

            .tree li::after {
                border-top: 1px solid #999;
                height: 20px;
                top: 25px;
                width: 25px;
            }

            .tree li span {
                -moz-border-radius: 5px;
                -webkit-border-radius: 5px;
                border: 1px solid #999;
                border-radius: 5px;
                display: inline-block;
                padding: 3px 8px;
                text-decoration: none;
            }

            .tree li.parent_li > span {
                cursor: pointer;
            }

        .tree > ul > li::before, .tree > ul > li::after {
            border: 0;
        }

        .tree li:last-child::before {
            height: 30px;
        }

        .tree li.parent_li > span:hover, .tree li.parent_li > span:hover + ul li span {
            background: #eee;
            border: 1px solid #94a0b4;
            color: #000;
        }
</style>

<script type="text/javascript">
    $(function () {
        $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');

        //關閉子選單
        var children = $('li.parent_li').find(' > ul > li');
        children.hide();

        //點擊事件
        $('.tree li.parent_li > span').on('click', function (e) {
            var children = $(this).parent('li.parent_li').find(' > ul > li');
            if (children.is(":visible")) {
                children.hide('fast');
                $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-plus-sign').removeClass('icon-minus-sign');
            } else {
                children.show('fast');
                $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-minus-sign').removeClass('icon-plus-sign');
            }
            e.stopPropagation();
        });
    });
</script>
<asp:PlaceHolder ID="nav" runat="server">
<div class="tree well">
    <ul style="padding-left: 0px;">
        <asp:Repeater ID="repCategories" runat="server" OnItemDataBound="repCategories_ItemDataBound">
            <ItemTemplate>
                 <asp:HiddenField runat="server" ID="hidCategoryId" Value='<%# Eval("Id") %>' />
                <li>
                    <span class="glyphicon glyphicon-star"><%# Eval("Name") %></span> <a href="<%# string.Format("../Products.aspx?page=0&categoryId={0}", Eval("Id")) %>"></a>
                    <ul>
                        <asp:Repeater ID="repChildCategories" runat="server">
                            <ItemTemplate>
                                <li>
                                    <a href='Items.aspx?productId=<%# Eval("Id") %>&categoryId=<%# Eval("categoryId") %>'><span class="glyphicon glyphicon-flash"><%# Eval("Name") %></span></a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </li>

            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
        
    </asp:Repeater>
    </asp:PlaceHolder>
<%-- <asp:Repeater ID="repCategories" runat="server">
    <HeaderTemplate>
        <table cellspacing="0" border="0" style="border-collapse: collapse;">
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="<%= ControlStyle %>">
                <asp:HyperLink runat="server" ID="lnkCategory" 
                    NavigateUrl='<%# string.Format("~/Products.aspx?page=0&categoryId={0}", Eval("Id")) %>' 
                    Text='<%# Eval("Name") %>' />
                <asp:HiddenField runat="server" ID="hidCategoryId" Value='<%# Eval("Id") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater> --%>


