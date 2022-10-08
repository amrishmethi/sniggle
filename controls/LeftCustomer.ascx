<%@ Control Language="C#" ClassName="LeftCustomer" %>

<script runat="server">

</script>

<div class="col-sm-12 col-md-3 col-lg-3">
    <!-- Nav tabs -->
    <div class="dashboard_tab_button" data-aos="fade-up" data-aos-delay="0">
        <ul role="tablist" class="nav flex-column dashboard-list">
            <li><a class="nav-link btn btn-block btn-md btn-black-default-hover" href="/"><b>Home</b></a></li>
            <%--<li><a href="/my-account" class="nav-link btn btn-block btn-md btn-black-default-hover">My account</a></li>--%>
            <li><a href="/order-history" class="nav-link btn btn-block btn-md btn-black-default-hover">My orders</a></li>
            <li><a href="/addresses" class="nav-link btn btn-block btn-md btn-black-default-hover">My addresses</a></li>
            <li><a href="/identity" class="nav-link btn btn-block btn-md btn-black-default-hover">My personal information</a></li>
            <li><a href="/mywishlist" class="nav-link btn btn-block btn-md btn-black-default-hover">My wishlist</a></li>
            <li><a href="/change-password" class="nav-link btn btn-block btn-md btn-black-default-hover">Change Password</a></li>
            <li><a href="/Logout"
                class="nav-link btn btn-block btn-md btn-black-default-hover">logout</a></li>
        </ul>
    </div>
</div>
