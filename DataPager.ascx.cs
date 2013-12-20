using System;
using System.Web.UI.WebControls;

namespace pSale.UserControls
{
    public partial class DataPager : System.Web.UI.UserControl
    {
        private const int maxPagesToDisplay = 5;
        private int startPageNumber;
        private int endPageNumber;

        #region Properties
        private int pageSize;
        private int startRecordNumber;
        private int endRecordNumber;
        private int totalRecords;
        private int currentPageIndex = 0;
        private int totalPages;


        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        public int StartRecordNumber
        {
            get { return (currentPageIndex * pageSize) + 1; }
            set { startRecordNumber = value; }
        }
        public int EndRecordNumber
        {
            get { return ((currentPageIndex + 1) * pageSize) > totalRecords ? totalRecords : ((currentPageIndex + 1) * pageSize); }
            set { endRecordNumber = value; }
        }
        public int TotalRecords
        {
            get { return totalRecords; }
            set { totalRecords = value; }
        }
        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set { currentPageIndex = value; }
        }
        public int TotalPages
        {
            get { return Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalRecords) / Convert.ToDecimal(pageSize))); }
            set { totalPages = value; }
        }
        #endregion
        public delegate void GetPagedRecordsHandler(int startIndex);
        public event GetPagedRecordsHandler GetPagedRecords;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetPaginationInfo()
        {
            lblCurrentPageNumber.Text = Convert.ToString(currentPageIndex + 1);
            lblTotalRecords.Text = Convert.ToString(totalRecords);
            lblTotalPages.Text = Convert.ToString(this.TotalPages);
            lblStartRecordNumber.Text = Convert.ToString(this.StartRecordNumber);
            lblEndRecordNumber.Text = Convert.ToString(this.EndRecordNumber);
            hidPageSize.Value = Convert.ToString(pageSize);
            if (currentPageIndex > 0)
            {
                lnkFirst.Enabled = true;
                lnkPrev.Enabled = true;
            }
            else
            {
                lnkFirst.Enabled = false;
                lnkPrev.Enabled = false;
            }
            if ((currentPageIndex + 1) != TotalPages)
            {
                lnkLast.Enabled = true;
                lnkNext.Enabled = true;
            }
            else
            {
                lnkLast.Enabled = false;
                lnkNext.Enabled = false;
            }
            if (currentPageIndex == 0)
            {
                startPageNumber = currentPageIndex + 1;
                endPageNumber = (TotalPages < maxPagesToDisplay) ? TotalPages : maxPagesToDisplay;
                hidStartPageNumber.Value = startPageNumber.ToString();
                hidEndPageNumber.Value = endPageNumber.ToString();
            }
            else
            {
                startPageNumber = Convert.ToInt32(hidStartPageNumber.Value);
                endPageNumber = Convert.ToInt32(hidEndPageNumber.Value);
            }
            lnkPrevPages.Visible = false;
            lnk1.Visible = false;
            lnk2.Visible = false;
            lnk3.Visible = false;
            lnk4.Visible = false;
            lnk5.Visible = false;
            lnkNextPages.Visible = false;
            int j = 1;
            for (int i = startPageNumber; i <= endPageNumber; i++)
            {
                LinkButton lb = (LinkButton)this.FindControl("lnk" + j.ToString());
                lb.Text = i.ToString();
                lb.CommandArgument = i.ToString();
                lb.Visible = true;

                if (currentPageIndex + 1 == i)
                {
                    //Apply css to selected link
                    lb.CssClass = "dpSelectedLink";
                }
                else
                {
                    lb.CssClass = "";
                }
                j++;
            }
            if (endPageNumber < TotalPages)
            {
                lnkNextPages.Visible = true;
            }
            if (startPageNumber > maxPagesToDisplay)
            {
                lnkPrevPages.Visible = true;
            }
        }
        protected void lnkFirst_Click(object sender, EventArgs e)
        {
            currentPageIndex = 0;
            startRecordNumber = currentPageIndex + 1;
            if (GetPagedRecords != null)
            {
                GetPagedRecords(startRecordNumber - 1);
            }
        }
        protected void lnkPrev_Click(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32(lblCurrentPageNumber.Text) - 1;
            currentPageIndex = currentPageIndex - 1;
            pageSize = Convert.ToInt32(hidPageSize.Value);
            startRecordNumber = (currentPageIndex * pageSize) + 1;

            startPageNumber = Convert.ToInt32(hidStartPageNumber.Value);
            if (Convert.ToInt32(lblCurrentPageNumber.Text) == startPageNumber)
            {
                endPageNumber = startPageNumber - 1;
                startPageNumber = startPageNumber - maxPagesToDisplay;
                hidStartPageNumber.Value = startPageNumber.ToString();
                hidEndPageNumber.Value = endPageNumber.ToString();
            }

            if (GetPagedRecords != null)
            {
                GetPagedRecords(startRecordNumber - 1);
            }
        }
        protected void lnkNext_Click(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32(lblCurrentPageNumber.Text);
            pageSize = Convert.ToInt32(hidPageSize.Value);
            startRecordNumber = currentPageIndex * pageSize + 1;

            endPageNumber = Convert.ToInt32(hidEndPageNumber.Value);
            totalPages = Convert.ToInt32(lblTotalPages.Text);
            if (currentPageIndex == endPageNumber)
            {
                startPageNumber = currentPageIndex + 1;
                //if ((totalPages - maxPagesToDisplay) > (endPageNumber + maxPagesToDisplay))
                if (totalPages > (endPageNumber + maxPagesToDisplay))
                {
                    endPageNumber = endPageNumber + maxPagesToDisplay;
                }
                else
                {
                    endPageNumber = totalPages;
                }
                hidStartPageNumber.Value = startPageNumber.ToString();
                hidEndPageNumber.Value = endPageNumber.ToString();
            }
            if (GetPagedRecords != null)
            {
                GetPagedRecords(startRecordNumber - 1);
            }
        }
        protected void lnkLast_Click(object sender, EventArgs e)
        {
            currentPageIndex = Convert.ToInt32(lblTotalPages.Text) - 1;
            pageSize = Convert.ToInt32(hidPageSize.Value);
            startRecordNumber = currentPageIndex * pageSize + 1;

            totalPages = Convert.ToInt32(lblTotalPages.Text);
            if (totalPages > maxPagesToDisplay)
            {
                endPageNumber = totalPages;
                if (endPageNumber % maxPagesToDisplay == 0)
                {
                    startPageNumber = endPageNumber - maxPagesToDisplay + 1;
                }
                else
                {
                    startPageNumber = endPageNumber - (endPageNumber % maxPagesToDisplay) + 1;
                }
                hidStartPageNumber.Value = startPageNumber.ToString();
                hidEndPageNumber.Value = endPageNumber.ToString();
            }
            if (GetPagedRecords != null)
            {
                GetPagedRecords(startRecordNumber - 1);
            }
        }

        protected void lnkPrevPages_Click(object sender, EventArgs e)
        {
            endPageNumber = Convert.ToInt32(hidEndPageNumber.Value);
            startPageNumber = Convert.ToInt32(hidStartPageNumber.Value);
            endPageNumber = startPageNumber - 1;
            startPageNumber = startPageNumber - maxPagesToDisplay;
            hidStartPageNumber.Value = startPageNumber.ToString();
            hidEndPageNumber.Value = endPageNumber.ToString();

            currentPageIndex = endPageNumber - 1;
            pageSize = Convert.ToInt32(hidPageSize.Value);
            startRecordNumber = currentPageIndex * pageSize + 1;
            if (GetPagedRecords != null)
            {
                GetPagedRecords(startRecordNumber - 1);
            }
        }
        protected void lnkSpecificPage_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            currentPageIndex = Convert.ToInt32(lb.CommandArgument) - 1;
            pageSize = Convert.ToInt32(hidPageSize.Value);
            startRecordNumber = currentPageIndex * pageSize + 1;
            if (GetPagedRecords != null)
            {
                GetPagedRecords(startRecordNumber - 1);
            }
        }
        protected void lnkNextPages_Click(object sender, EventArgs e)
        {
            endPageNumber = Convert.ToInt32(hidEndPageNumber.Value);
            totalPages = Convert.ToInt32(lblTotalPages.Text);
            startPageNumber = endPageNumber + 1;
            if (totalPages > (endPageNumber + maxPagesToDisplay))
            {
                endPageNumber = endPageNumber + maxPagesToDisplay;
            }
            else
            {
                endPageNumber = totalPages;
            }
            hidStartPageNumber.Value = startPageNumber.ToString();
            hidEndPageNumber.Value = endPageNumber.ToString();

            currentPageIndex = startPageNumber - 1;
            pageSize = Convert.ToInt32(hidPageSize.Value);
            startRecordNumber = currentPageIndex * pageSize + 1;
            if (GetPagedRecords != null)
            {
                GetPagedRecords(startRecordNumber - 1);
            }
        }
    }
}