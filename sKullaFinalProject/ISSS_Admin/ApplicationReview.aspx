<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicationReview.aspx.cs" Inherits="ISSS_Admin_ApplicationReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="leftPanelContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightPanelContent" Runat="Server">
    <h3>
        <br />
&nbsp; Applications ready for review</h3>
    <p>
        &nbsp;
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CellSpacing="4" DataKeyNames="student_id" DataSourceID="ApplicaationsSqlDataSource" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField SelectText="View Offer Letter" ShowSelectButton="True" />
                <asp:BoundField DataField="student_name" HeaderText="Student Name" SortExpression="student_name" />
                <asp:BoundField DataField="student_id" HeaderText="Student ID" ReadOnly="True" SortExpression="student_id" />
                <asp:BoundField DataField="degree_level" HeaderText="Degree Level" SortExpression="degree_level" />
                <asp:BoundField DataField="program_name" HeaderText="Program Name" SortExpression="program_name" />
                <asp:BoundField DataField="gpa" HeaderText="GPA" SortExpression="gpa" />
                <asp:BoundField DataField="employer_name" HeaderText="Employer Name" SortExpression="employer_name" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Application_Status">
                            <asp:ListItem>Approve/Deny</asp:ListItem>
                            <asp:ListItem>Approved</asp:ListItem>
                            <asp:ListItem>Denied</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="ApplicaationsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:applicationsConString %>" SelectCommand="SELECT [student_name], [student_id], [degree_level], [program_name], [gpa], [employer_name] FROM [Applications]"></asp:SqlDataSource>
    </p>
    <p>
        &nbsp;&nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="statusLabel" runat="server"></asp:Label>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

