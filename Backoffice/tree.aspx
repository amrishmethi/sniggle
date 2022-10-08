<%@ Page Title="" Language="C#" MasterPageFile="~/Backoffice/AdminMasterPage.master" AutoEventWireup="true" CodeFile="tree.aspx.cs" Inherits="Backoffice_tree" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
     <CKEditor:CKEditorControl ID="txtareaDescription" BasePath="../Admin/ckeditor/" runat="server"></CKEditor:CKEditorControl>

     <script type="text/javascript">
         $(function () {
             CKEDITOR.replace('<%=txtareaDescription.ClientID %>', { filebrowserImageUploadUrl: 'Upload.ashx' });
         });
     </script>
  </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
  
</asp:Content>

