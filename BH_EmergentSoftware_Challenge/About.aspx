<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BH_EmergentSoftware_Challenge.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
    <div class="col-md-4">
        <h2>General</h2>
        <p>This is Broderick Hudson's solution to the example problem that I was given as part of the interview process for Emergent Software.</p>
        <p>The parts that matter are located in the following places:</p>
        <ul>
            <li>SoftwareFilterer.cs houses the logic for filtering the software.</li>
            <li>Default.aspx is the main page, and Default.aspx.cs is where the button event is.</li>
            <li>Software.cs is the code that was in the given document.</li>
        </ul>
    </div>
    <div class="col-md-4">
        <h2>Explanation</h2>
        <p>It began as a ASP.NET Framework (4.7.2) project, and I used the Webforms template. I redid the Site.Master page.</p>
        <p>I started by defining the objects that I'd need, and then writing tests that match the four test cases provided in the document.</p>
        <p>Then I worked through the objects themselves to try and get the tests to pass.</p>
        <p>Once the tests passed and I knew I could filter the software per the requirements, I got to working through the page, which was pretty fast.</p>
    </div>
    <div class="col-md-4">
        <h2>What I'd Do Differently</h2>
        <p>If I had more time, I would do a few additional things and do a few other things differently. They are as follows:</p>
        <ul>
            <li>Use .NET Core instead of framework.</li>
            <li>Use React.js instead of an ASP.Net repeater to get away from the post-backs.</li>
            <li>Add images and a description to each card.</li>
            <li>Trim down all of the extra scripts and content attached to this project.</li>
            <li>Additional polishing in web view.</li>
            <li>Think about how to scale the data retrieval.</li>
        </ul>
    </div>
</div>
</asp:Content>
