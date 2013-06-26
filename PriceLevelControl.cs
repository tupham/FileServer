using System.ComponentModel;
using System.Windows.Forms;
using Onixs.CmeFastHandler;

namespace CmeFastHandlerSample
{
    public partial class PriceLevelControl : UserControl
    {
        public PriceLevelControl()
        {
            InitializeComponent();
        }

        private int _level;

        [DefaultValue(0)]
        public int Level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
                this.lblLevel.Text = string.Format("Level {0}:", this._level);
            }
        }

        private double _price;

        [DefaultValue(0.0)]
        public double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                if (this._price != value)
                {
                    this._price = value;
                    this.txtPrice.Text = this._price != 0.0 ? this._price.ToString() : "";
                }
            }
        }

        private int _quantity;

        [DefaultValue(0)]
        public int Quantity
        {
            get
            {
                return this._quantity;
            }
            set
            {
                if (this._quantity != value)
                {
                    this._quantity = value;
                    this.txtQuantity.Text = this._quantity != 0 ? this._quantity.ToString() : "";
                }
            }
        }

        private int _orderCount;

        [DefaultValue(0)]
        public int OrderCount
        {
            get
            {
                return this._orderCount;
            }
            set
            {
                if (this._orderCount != value)
                {
                    this._orderCount = value;
                    this.txtOrderCount.Text = this._orderCount != 0 ? this._orderCount.ToString() : "";
                }
            }
        }

        public void SetPriceLevel(IPriceLevel level)
        {
            Price = level.Price;
            Quantity = level.Quantity;
            OrderCount = level.NumberOfOrders;
        }

        public void Reset()
        {
            Price = 0.0;
            Quantity = 0;
            OrderCount = 0;
        }
    }
}