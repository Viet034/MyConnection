﻿namespace ConnectMySql.Model.DTO;

public class OrderDetailDTO
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal? Price { get; set; }
}
