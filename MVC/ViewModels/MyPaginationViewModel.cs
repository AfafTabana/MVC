namespace MVC.ViewModels
{
    public class MyPaginationViewModel<T> :List<T>
    {
        public int pageIndex { get; set; }

        public int totalpages { get; set; }

        public bool HavePriviousPage => pageIndex > 1; 

        public bool HaveNextPage => pageIndex < totalpages; 


        public MyPaginationViewModel(List<T> items , int pageSize , int _pageIndex , int count )
        {
            pageIndex = _pageIndex;
            totalpages =(int)Math.Ceiling(count / (double)pageSize); 
            this.AddRange(items);   
        }

        public static MyPaginationViewModel<T> Create(IQueryable<T> item, int _pageIndex, int pagesize)
        {
            var count = item.Count();
            var items = item.Skip((_pageIndex -1)*pagesize).Take(pagesize).ToList();

            return new MyPaginationViewModel<T>(items, pagesize , _pageIndex , count);
        }


    }
}
