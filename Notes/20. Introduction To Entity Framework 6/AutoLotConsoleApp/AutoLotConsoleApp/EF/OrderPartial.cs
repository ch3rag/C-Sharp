﻿namespace AutoLotConsoleApp.EF {
    using System;
    public partial class Order {
        public override string ToString() {
            return String.Format("CarId: {0} CustomerId: {1} OrderId: {2}", this.CardId, this.CustId, this.OrderId);
        }
    }
}