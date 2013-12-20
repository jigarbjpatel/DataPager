DataPager
=========

Data Pager in C# ASP.Net WebForms

To use register the control in .aspx file and add following lines in Page_Load of Code-behind (where pager is id of the user control)

1. pager.PageSize = 10;
2. pager.GetPagedRecords += new DataPager.GetPagedRecordsHandler(pager_GetPagedRecords);

And add pager_GetPagedRecords method

void pager_GetPagedRecords(int startIndex)
{
  //Write the binding logic 
}
