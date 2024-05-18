namespace ZKKADotNetCore.PizzaApi.Queries
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery { get; } = @"
            select po.*, p.Pizza, p.Price from [dbo].Tbl_PizzasOrder po 
            inner join Tbl_Pizza p on p.PizzaId = po.PizzaId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";

        public static string PizzaOrderDetailQuery { get; } = @"
            select pod.*, pe.PizzaExtraName, pe.Price from [dbo].Tbl_PizzasOrderDetail pod
            inner join Tbl_PizzaExtra pe on pe.PizzaExtraId = pod.PizzaExtraId
            where PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo;";
    }
}
