<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/master/main.master" AutoEventWireup="true" CodeFile="pwdChange.aspx.cs" Inherits="pwdChange" %>

<asp:Content ID="Content2" ContentPlaceHolderID="page_head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <div class="form-group row-centered"> <h2>Change password</h2></div>
    <hr />
    <div class="row">
        <br /><br /><hr /><br />
        <div class="col-md-12">
            <div class="form-group">
                <asp:TextBox ID="old_pass" CssClass="form-control text-center alert-success" TextMode="Password" placeholder="Old password" runat="server" Height="50px" Font-Size="16px"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="old_pass" CssClass="warningLbl" ErrorMessage="*Old password is required" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">

                <asp:TextBox ID="new_pass" CssClass="form-control  text-center alert-success" TextMode="Password" placeholder="New password" runat="server" Height="50px" Font-Size="16px"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="new_pass" CssClass="warningLbl" ErrorMessage="*Password cannot be empty!" runat="server"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:TextBox ID="verify_new_pass" CssClass="form-control text-center alert-success" TextMode="Password" placeholder="Retype new password" runat="server" Height="50px" Font-Size="16px"></asp:TextBox>
            </div>
            <div class="form-group row-centered">
                <asp:Button ID="change_password_btn" CssClass="btn btn-primary" Text="Save" runat="server" OnClick="change_password_btn_Click" Width="400px" Height="50px" />
                <asp:Label runat="server" ID="msg" CssClass="warningLbl" ></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content> 