<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="DesktopModules_AIS_News_Detail_Control" %>
<link rel="stylesheet" type="text/css" href="<%=libpath %>slick-carousel-1.8.1/slick.css" />
<link rel="stylesheet" type="text/css" href="<%=libpath %>slick-carousel-1.8.1/slick-theme.css" />
<script type="text/javascript" src="<%=libpath %>slick-carousel-1.8.1/slick.min.js"></script>

<%--<asp:Image ID="Image1" runat="server" />--%>

<h1><asp:Label ID="LBL_Titre" runat="server" Text="" /></h1>

<div class="text-right">
	<asp:HyperLink ID="HLK_Club" runat="server" CssClass="Normal" />
	<asp:Label ID="LBL_Date" runat="server" Text="" CssClass="Date Normal"></asp:Label>
</div>
<div class="pe-spacer size10"></div>

<p class="text-justify Normal">
	<asp:Literal ID="LBL_Detail" runat="server" Text="" ></asp:Literal>
</p>

<script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "NewsArticle",
  "url":"<%= HOST + Request.RawUrl %>",
  "image":"<%= HOST + news_photo %>",
  "headline": "<%= page_title %>",
  "datePublished": "<%= news_dt %>"
}
    </script>
    <script>
        function ShareCopyLink(event) {
            event.stopPropagation();
            navigator.clipboard.writeText(window.location.href);
            document.getElementById("ShareLinkCopy").style.display = "none";
            document.getElementById("ShareLinkCopied").style.display = "block";
            setTimeout(() => {
                document.getElementById("ShareLinkCopy").style.display = "block";
                document.getElementById("ShareLinkCopied").style.display = "none";
            }, 3000);
        }
    </script>
    <div class="partager">

        <ul>
            <li>
                <button type="button" onclick="window.ShareCopyLink(event)" aria-label="Copier le lien" title="Copier le lien" data-share-type="copy" rel="noopener">
                    <span id="ShareLinkCopy">
                        <svg width="16" height="16" viewBox="0 0 22 22" aria-hidden="true" focusable="false">
                            <path d="M13.4 10.6a5.1 5.1 0 0 1 1.6 3.6c0 1.4-.6 2.7-1.6 3.7l-2.6 2.6A5.1 5.1 0 0 1 7.2 22a5.1 5.1 0 0 1-3.7-1.5A5.1 5.1 0 0 1 2 16.8c0-1.4.5-2.7 1.5-3.6l2.6-2.6.2-.2v.4l.3 1.8-1.9 1.8a3.4 3.4 0 0 0-1 2.4c0 1 .4 1.8 1 2.5a3.5 3.5 0 0 0 5 0l2.5-2.6a3.4 3.4 0 0 0 1-2.5c0-.9-.3-1.8-1-2.4a3.5 3.5 0 0 0-.6-.5 1.7 1.7 0 0 1-.1-.5c0-.5.2-1 .5-1.2a5.2 5.2 0 0 1 1.4 1zm6-6A5.1 5.1 0 0 1 21 8.1a5.2 5.2 0 0 1-1.5 3.6l-2.6 2.6-.2.2v-.4a7 7 0 0 0-.3-1.8l1.9-1.8a3.4 3.4 0 0 0 1-2.4c0-1-.4-1.8-1-2.5a3.4 3.4 0 0 0-2.5-1c-.9 0-1.8.4-2.4 1l-2.6 2.6a3.4 3.4 0 0 0-1 2.5 3.4 3.4 0 0 0 1.6 2.9 1.7 1.7 0 0 1-.4 1.7 5.2 5.2 0 0 1-1.4-1A5.1 5.1 0 0 1 8 10.8C8 9.4 8.6 8 9.6 7l2.6-2.6A5.1 5.1 0 0 1 15.8 3c1.4 0 2.7.5 3.7 1.5z"></path>
                        </svg>
                        <span aria-hidden="true">Copier le lien</span>
                    </span>
                    <span id="ShareLinkCopied" style="display:none">
                        <svg width="24" height="18" viewBox="0 0 13 13" aria-hidden="true" focusable="false">
                            <path d="M13.1 4.26a.82.82 0 0 0-1.17-.03l-5.3 5.08L4.08 6.7a.82.82 0 0 0-1.17-.02.85.85 0 0 0-.02 1.2l3.1 3.2a.82.82 0 0 0 1.17.03l5.9-5.65a.85.85 0 0 0 .04-1.19Z"></path>
                        </svg>
                        <span aria-hidden="true">Lien copié</span>
                    </span>
                </button>
            </li>
            <li>
                <a aria-label="Partager via e-mail" title="Partager via e-mail" data-share-type="mail" href="<%=href_mail %>">
                    <span>
                        <svg width="24" height="24" viewBox="0 0 24 24" aria-hidden="true" focusable="false">
                            <path d="M18.75 4.5H5.25A2.25 2.25 0 0 0 3 6.75v10.5a2.25 2.25 0 0 0 2.25 2.25h13.5A2.25 2.25 0 0 0 21 17.25V6.75a2.25 2.25 0 0 0-2.25-2.25zm-.23 3.6l-6 5.25a1.39 1.39 0 0 1-.52.15 1.39 1.39 0 0 1-.53-.15l-6-5.25a.74.74 0 1 1 .98-1.13l5.47 4.8 5.48-4.8a.73.73 0 0 1 1.05.08.68.68 0 0 1 .07 1.05z"></path>
                        </svg>
                    </span>
                    <span aria-hidden="true">Mail</span>
                </a>
            </li>
            <li>
                <a aria-label="Partager via Facebook" title="Partager via Facebook" data-share-type="facebook" href="<%=href_fb %>" rel="noopener" target="_blank">
                    <span>
                        <svg width="24" height="24" viewBox="0 0 24 24" aria-hidden="true" focusable="false">
                            <path d="M9.3 21v-8.2H6V9.5h3.3v-2c0-3 1.9-4.5 4.6-4.5l2.7.1v3.2h-1.9C13.2 6.3 13 7 13 8v1.5h4.3l-1.7 3.3H13V21H9.3z"></path>
                        </svg>
                    </span>
                    <span aria-hidden="true">Facebook</span>
                </a>
            </li>
            <li>
                <a aria-label="Partager via X (Twitter)" title="Partager via X (Twitter)" data-share-type="twitter" href="<%=href_twitter %>" rel="noopener" target="_blank">
                    <span>
                        <svg width="24" height="24" viewBox="0 0 24 24" aria-hidden="true" class="r-18jsvk2 r-4qtqp9 r-yyyyoo r-16y2uox r-8kz0gk r-dnmrzs r-bnwqim r-1plcrui r-lrvibr r-lrsllp"><g><path d="M18.244 2.25h3.308l-7.227 8.26 8.502 11.24H16.17l-5.214-6.817L4.99 21.75H1.68l7.73-8.835L1.254 2.25H8.08l4.713 6.231zm-1.161 17.52h1.833L7.084 4.126H5.117z"></path></g></svg>
                    </span>
                    <span aria-hidden="true">Twitter</span>
                </a>
            </li>
            <li>
                <a aria-label="Partager via Linkedin" title="Partager via Linkedin" data-share-type="linkedin" href="<%= href_linkedin %>" rel="noopener" target="_blank">
                    <span>
                        <svg width="24" height="24" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg" aria-hidden="true" focusable="false">
                            <path d="M17.5 16.67h-3.34v-4.7c0-1.23-.53-2.07-1.68-2.07-.88 0-1.37.57-1.6 1.11-.08.2-.07.47-.07.74v4.92H7.5s.04-8.33 0-9.08h3.31V9c.2-.62 1.26-1.51 2.95-1.51 2.1 0 3.74 1.3 3.74 4.12v5.05Zm-13.34-10h-.02c-1 0-1.64-.74-1.64-1.67 0-.95.66-1.67 1.68-1.67 1.01 0 1.63.72 1.65 1.67a1.6 1.6 0 0 1-1.67 1.67ZM2.5 7.5h3.33v9.17H2.5V7.5Z"></path>
                        </svg>
                    </span>
                    <span aria-hidden="true">Linkedin</span>
                </a>
            </li>
            <li>
                <a aria-label="Partager via WhatsApp" title="Partager via WhatsApp" data-share-type="whatsapp" href="<%= href_whatsapp %>" rel="noopener" target="_blank">
                    <span>
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" aria-hidden="true" focusable="false">
                            <path d="M12 2a10 10 0 0 1 0 20 10 10 0 0 1-5.5-1.7l-3.8 1.3 1.2-3.7A10 10 0 0 1 2 12 10 10 0 0 1 12 2zM9.2 7c-.2-.4-.3-.4-.6-.4a5.6 5.6 0 0 0-.4 0c-.3 0-.7 0-1 .3-.3.3-1 1-1 2.5 0 1.4 1 2.8 1.2 3 .1.2 2 3.2 5 4.4 2.3 1 3 .8 3.5.7.7-.1 1.7-.7 2-1.4.2-.7.2-1.2 0-1.4l-.5-.3-2-1c-.2 0-.5 0-.7.3-.3.4-.5.8-.8 1-.1.2-.4.2-.7.1-.3-.1-1.2-.4-2.3-1.4a8.9 8.9 0 0 1-1.6-2c-.2-.3 0-.5 0-.7l.5-.5c.2-.1.3-.2.3-.4v-.6l-.9-2.1z"></path>
                        </svg>
                    </span>
                    <span aria-hidden="true">WhatsApp</span>
                </a>
            </li>
        </ul>
    </div>