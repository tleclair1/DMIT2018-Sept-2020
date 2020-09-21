using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion

namespace WebApp.SamplePages
{
    public partial class SearchByDDL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                BindArtistList();
            }
        }

        protected void BindArtistList()
        {
            ArtistController sysmgr = new ArtistController();
            List<SelectionList> info = sysmgr.Artist_List();

            //info.Sort((x, y) => x.DisplayText.CompareTo(y.DisplayText));

            ArtistList.DataSource = info;
            ArtistList.DataTextField = nameof(SelectionList.DisplayText);
            ArtistList.DataValueField = nameof(SelectionList.ValueId);
            ArtistList.DataBind();

            //ListItem prompt = new ListItem();
            //prompt.Value = "0";
            //prompt.Text = "Select an artist...";
            //ArtistList.Items.Insert(0, prompt);

            ArtistList.Items.Insert(0, new ListItem("Select an artist..."));
        }

        protected void SearchAlbums_Click(object sender, EventArgs e)
        {
            if (ArtistList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select an artist for search.";
                AlbumArtistList.DataSource = null;
                AlbumArtistList.DataBind();
            }
            else
            {
                AlbumController sysmgr = new AlbumController();
                List<AlbumArtist> info = sysmgr.Album_FindByArtist(int.Parse(ArtistList.SelectedValue));
                AlbumArtistList.DataSource = info;
                AlbumArtistList.DataBind();
            }
        }

        protected void AlbumArtistList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agvrow = AlbumArtistList.Rows[AlbumArtistList.SelectedIndex];
            MessageLabel.Text = (agvrow.FindControl("AlbumId") as Label).Text;
        }
    }
} 