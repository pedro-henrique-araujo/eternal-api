namespace Eternal.DataAccess
{
    public class PaginationInfoExtractor
    {
        public static PaginationInfo Extract(int? page, int numberOfRecords)
        {
            var paginationInfo = new PaginationInfo();
            paginationInfo.Skip = (Math.Max(page ?? 1, 1) - 1) * 10;
            paginationInfo.Take = 10;
            paginationInfo.NumberOfPages = Convert.ToInt16(Math.Ceiling(numberOfRecords / (decimal)10));
            return paginationInfo;
        }
    }
}