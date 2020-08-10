<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BH_EmergentSoftware_Challenge._Default" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Broderick Hudson's Emergent Software Interview Problem</h3>
        <p class="lead">The default page (this one) is the implementation, and the About page is a brief explanation of what I did.</p>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <asp:TextBox ID="txtVersion" runat="server" placeholder="[Major version].[Minor version].[Patch]" CssClass="form-control" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtVersion" ValidationExpression="[\d]+[.]*[\d]*[.]*[\d]*" Text="Please give a valid version number." CssClass="text-danger" />
            </div>
            <div class="col">
                <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-outline-primary" OnClick="btnRefresh_Click" Text="Refresh" />
            </div>
        </div>
    </div>

    <div class="container">
        <asp:Repeater ID="rptSoftware" runat="server">
            <HeaderTemplate>
                <div class="list-group">
            </HeaderTemplate>
                <ItemTemplate>
                    <div class="list-group-item" style="width: 45rem;">
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#softwareModal" data-name="<%# DataBinder.Eval(Container.DataItem, "Name") %>" data-version="<%# DataBinder.Eval(Container.DataItem, "Version") %>"><%# DataBinder.Eval(Container.DataItem, "Name") %></button>
                        <%--<h4 class="list-group-item-heading"><%# DataBinder.Eval(Container.DataItem, "Name") %></h4>--%>
                        <p class="list-group-item-text"> Version: <%# DataBinder.Eval(Container.DataItem, "Version") %></p>
                    </div>
                </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <div class="modal fade" id="softwareModal" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <label id="modal-version" />
                        </div>
                        <div class="row">
                            <p>If there was additional data, it could go here.</p>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <%--This script makes the modal window work.--%>
    <script>
        $('#softwareModal').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget) // Button that triggered the modal
            var name = button.data('name') // Extract info from data-* attributes
            var version = button.data('version')
            // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
            var modal = $(this)
            modal.find('.modal-title').text(name)
            modal.find('#modal-version').text('Version: ' + version)
        })
    </script>
</asp:Content>
