using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Customization;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using ExchFrontEnd.BusinessObjects;
using ExchFrontEnd.GridHelpers;
using ExchFrontEnd.Properties;
using ExchFrontEnd.ResourceMessage;

namespace ExchFrontEnd
{
    public partial class DynamicOrderForm : CustomDockContent
    {
        #region private properties

        private DynamicPostingTemplateDataItem _bidTemplate;

        private InstrumentBook _bidInstrument;

        private bool _isBidSelectedTemplate;

        private bool _isBidVolChange;

        private bool _isBidDiffChange;

        private decimal _bidOldDifferential;

        private decimal _bidDifferential;

        private decimal _bidOldVol;

        private decimal _bidVol;

        private string _bidOrdId;

        private OrderState _bidOrderStatus = OrderState.enUndefined;

        private Order _bidOrder;


        private DynamicPostingTemplateDataItem _askTemplate;

        private InstrumentBook _askInstrument;

        private bool _isAskSelectedTemplate;

        private bool _isAskVolChange = true;

        private bool _isAskDiffChange;

        private decimal _askOldDifferential;

        private decimal _askDifferential;

        private decimal _askOldVol;

        private decimal _askVol;

        private string _askOrdId;

        private OrderState _askOrderStatus = OrderState.enUndefined;

        private Order _askOrder;

        #endregion

        #region constructor

        public DynamicOrderForm()
        {
            InitializeComponent();
            Icon = Resources.DynamicFormIcon;
            Init();
        }

        public DynamicOrderForm(DynamicPostingTemplateDataItem selectedItem)
            : this()
        {
            this.bidTemplateLookUp.EditValue = selectedItem;
            this.askTemplateLookUp.EditValue = selectedItem;
        }

        #endregion

        #region initialize

        private void Init()
        {
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Init.");
            InitComboBox();
            InitButton();
            InitTextField();
            InitSpin();
            InitEvent();
        }

        private void InitEvent()
        {
            if (Singleton<DynamicPostingController>.Instance.DisplayDataItems != null)
            {
                Singleton<DynamicPostingController>.Instance.DisplayDataItems.Removed +=
                    DynamicPostingTemplateDataItemsRemoved;
            }
            else
            {
                LogManager.Log(event_type.et_Internal, severity_type.st_info,
                                           LocalizeManager.GetErrorMessage(ErrorMessageClient.DynamicTemplateCannotConnectToServer));
            }

            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Begin InitOrderChangeEvent.");
            Singleton<OrderCollection>.Instance.Added += OrderCollectionAdded;
            Singleton<OrderCollection>.Instance.ItemUpdated += OrderCollectionItemUpdated;
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Finished InitOrderChangeEvent.");
        }

        /// <summary>
        ///     Initialize all combox in form dynamic
        /// </summary>
        private void InitComboBox()
        {
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Begin InitComboBox.");
            this.bidTemplateLookUp.Properties.ShowHeader = false;
            this.bidTemplateLookUp.Properties.ShowFooter = false;

            this.bidTemplateLookUp.Properties.DataSource =
                Singleton<DynamicPostingController>.Instance.DisplayDataItems;

            this.bidTemplateLookUp.Properties.DisplayMember = "Name";

            this.bidTemplateLookUp.Properties.Columns.Add(new LookUpColumnInfo(this.bidTemplateLookUp.Properties.DisplayMember));

            this.askTemplateLookUp.Properties.ShowHeader = false;
            this.askTemplateLookUp.Properties.ShowFooter = false;

            this.askTemplateLookUp.Properties.DataSource =
                Singleton<DynamicPostingController>.Instance.DisplayDataItems;

            this.askTemplateLookUp.Properties.DisplayMember = "Name";

            this.askTemplateLookUp.Properties.Columns.Add(new LookUpColumnInfo(this.bidTemplateLookUp.Properties.DisplayMember));

            this.bidTemplateLookUp.EditValueChanged += BidFormulaLookUpValueChanged;
            this.askTemplateLookUp.EditValueChanged += AskFormulaLookUpValueChanged;

            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Finished InitComboBox.");
        }

        /// <summary>
        ///     Delegate all event of buttons.
        /// </summary>
        private void InitButton()
        {
            this.reBidButton.LookAndFeel.SetSkinStyle("NEO_Blue_button");
            this.reAskButton.LookAndFeel.SetSkinStyle("NEO_Red_button");

            this.bidCheckPriceButton.Click += BidCheckPriceButtonClick;
            this.askCheckPriceButton.Click += AskCheckPriceButtonClick;

            this.bidCancelButton.Click += BidCancelButtonClick;
            this.askCancelButton.Click += AskCancelButtonClick;

            this.reBidButton.Click += ReBidButtonClick;
            this.reAskButton.Click += ReAskButtonClick;

            UpdateButtonStatus(true);
            UpdateButtonStatus(false);
        }

        private void InitTextField()
        {
            this.bidMinIncrementTextField.Enabled = false;
            this.askMinIncrementTextField.Enabled = false;

            this.bidMinIncrementTextField.Validating += BidMinIncrementTextFieldValidating;
            this.bidMinIncrementTextField.EditValueChanged += BidMinIncrementTextFieldValueChanged;

            this.askMinIncrementTextField.Validating += AskMinIncrementTextFieldValidating;
            this.askMinIncrementTextField.EditValueChanged += AskMinIncrementTextFieldValueChanged;
        }

        private void InitSpin()
        {
            this.bidDiffSpin.Enabled = false;
            this.bidVolSpin.Enabled = false;

            this.askDiffSpin.Enabled = false;
            this.askVolSpin.Enabled = false;

            this.bidDiffSpin.EditValueChanged += BidDiffSpinEditValueChanged;
            this.askDiffSpin.EditValueChanged += AskDiffSpinEditValueChanged;

            this.bidVolSpin.EditValueChanged += BidVolSpinEditValueChanged;
            this.askVolSpin.EditValueChanged += AskVolSpinEditValueChanged;
        }

        private void DynamicPostingTemplateDataItemsRemoved(object sender, DynamicPostingTemplateDataItem parameter)
        {
            if (!Singleton<DynamicPostingController>.Instance.DisplayDataItems.Contains(this._bidTemplate))
            {
                this.reBidButton.Enabled = false;
                this.bidCheckPriceButton.Enabled = false;
	            this._isBidSelectedTemplate = false;
	            this._bidInstrument = null;
            }
            if (!Singleton<DynamicPostingController>.Instance.DisplayDataItems.Contains(this._askTemplate))
            {
                this.reAskButton.Enabled = false;
                this.askCheckPriceButton.Enabled = false;
	            this._isAskSelectedTemplate = false;
	            this._askInstrument = null;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if ((this._bidOrderStatus != OrderState.enUndefined && this._bidOrderStatus != OrderState.enCanceled && this._bidOrderStatus != OrderState.enFilled)
                || (this._askOrderStatus != OrderState.enUndefined && this._askOrderStatus != OrderState.enCanceled && this._askOrderStatus != OrderState.enFilled))
            {
                var result = XtraMessageBox.Show(this,
                                                 LocalizeManager.GetInfoMessage(
                                                     InfoMessageClient.CloseDynamicOrderFormConfirm),
                                                 "Confirm dialog",
                                                 MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    CancelAllOrder();
                    base.OnClosing(e);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                base.OnClosing(e);
            }
        }

        #endregion

        #region event

        private void AskVolSpinEditValueChanged(object sender, EventArgs e)
        {
            VolChanged(false);
        }

        private void BidVolSpinEditValueChanged(object sender, EventArgs e)
        {
            VolChanged(true);
        }

        private void AskDiffSpinEditValueChanged(object sender, EventArgs e)
        {
            DiffChanged(false);
        }

        private void BidDiffSpinEditValueChanged(object sender, EventArgs e)
        {
            DiffChanged(true);
        }

        private void AskMinIncrementTextFieldValueChanged(object sender, EventArgs e)
        {
            MinIncrementChanged(false);
        }

        private void AskMinIncrementTextFieldValidating(object sender, CancelEventArgs e)
        {
            MinIncrementValidating(false, e);
        }

        private void BidMinIncrementTextFieldValueChanged(object sender, EventArgs e)
        {
            MinIncrementChanged(true);
        }

        private void BidMinIncrementTextFieldValidating(object sender, CancelEventArgs e)
        {
            MinIncrementValidating(true, e);
        }

        private void ReAskButtonClick(object sender, EventArgs e)
        {
            ReOrder(false);
        }

        private void ReBidButtonClick(object sender, EventArgs e)
        {
            ReOrder(true);
        }

        private void AskCancelButtonClick(object sender, EventArgs e)
        {
            CancelOrder(false);
        }

        private void BidCancelButtonClick(object sender, EventArgs e)
        {
            CancelOrder(true);
        }

        private void AskCheckPriceButtonClick(object sender, EventArgs e)
        {
            CheckPrice(false);
        }

        private void BidCheckPriceButtonClick(object sender, EventArgs e)
        {
            CheckPrice(true);
        }

        private void AskFormulaLookUpValueChanged(object sender, EventArgs e)
        {
            SelectedTemplateChanged(false);
        }

        private void BidFormulaLookUpValueChanged(object sender, EventArgs e)
        {
            SelectedTemplateChanged(true);
        }

        /// <summary>
        ///     Delegate event for order be updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        private void OrderCollectionAdded(object sender, Order parameter)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ActionEventHandler<Order>(OrderCollectionAdded), sender, parameter);
                return;
            }
            if (parameter.OrderSide == OrderSide.OS_Buy)
            {
                if (parameter.OrigID == this._bidOrdId)
                {
                    this._bidOrder = parameter;
                }
                UpdateBidOrderStatus();
            }
            else
            {
                if (parameter.OrigID == this._askOrdId)
                {
                    this._askOrder = parameter;
                }
                UpdateAskOrderStatus();
            }
        }

        /// <summary>
        ///     Update status of order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="parameter"></param>
        private void OrderCollectionItemUpdated(object sender, Order parameter)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ActionEventHandler<Order>(OrderCollectionItemUpdated), sender, parameter);
                return;
            }
            if (this._bidOrder != null && parameter.OrderSide == OrderSide.OS_Buy)
            {
                if (parameter.ID == this._bidOrder.ID && parameter.OrderState == OrderState.enReplaced)
                {
                    this._bidOrder = parameter.ReplacedByOrder;
                }
                UpdateBidOrderStatus();
            }
            else if (this._askOrder != null && parameter.OrderSide == OrderSide.OS_Sell)
            {
                if (parameter.ID == this._askOrder.ID && parameter.OrderState == OrderState.enReplaced)
                {
                    this._askOrder = parameter.ReplacedByOrder;
                }
                UpdateAskOrderStatus();
            }
        }

        #endregion Event Register.

        public void CancelAllOrder()
        {
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Begin CancelAllOrder...");
            try
            {
                if (this._bidOrderStatus != OrderState.enUndefined && this._bidOrderStatus != OrderState.enCanceled &&
                    this._bidOrderStatus != OrderState.enFilled)
                {
                    using (var dynamicPostingServiceClient = ServiceFactory.GetDynamicPostingServiceClient())
                    {
                        if (Singleton<DynamicPostingController>.Instance.CheckDynamicPostingServiceAvailable())
                        {
                            dynamicPostingServiceClient.Cancel(this._bidOrdId);
                        }
                        else
                        {
                            LogManager.Log(event_type.et_Internal, severity_type.st_info,
                                           LocalizeManager.GetErrorMessage(ErrorMessageClient.DynamicTemplateCannotConnectToServer));
                        }
                    }
                }

                if (this._askOrderStatus != OrderState.enUndefined && this._askOrderStatus != OrderState.enCanceled &&
                    this._askOrderStatus != OrderState.enFilled)
                {
                    using (var dynamicPostingServiceClient = ServiceFactory.GetDynamicPostingServiceClient())
                    {
                        if (Singleton<DynamicPostingController>.Instance.CheckDynamicPostingServiceAvailable())
                        {
                            dynamicPostingServiceClient.Cancel(this._askOrdId);
                        }
                        else
                        {
                            LogManager.Log(event_type.et_Internal, severity_type.st_info,
                                           LocalizeManager.GetErrorMessage(ErrorMessageClient.DynamicTemplateCannotConnectToServer));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LogManager.Log(event_type.et_Internal, severity_type.st_info, exception.Message);
            }
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Finished CancelAllOrder.");
        }

        /// <summary>
        ///     Update status for bid order.
        /// </summary>
        private void UpdateBidOrderStatus()
        {
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Begin UpdateBidOrderStatus...");
            if (this._bidOrder != null)
            {
                LogManager.Log(event_type.et_Internal, severity_type.st_info, string.Format("UpdateBidOrderStatus...{0}", this._bidOrder.OrderState));
                this._bidOrderStatus = this._bidOrder.OrderState;
                this.bidOrderStatusTextField.Text = this._bidOrderStatus.ToStr();
                UpdateButtonStatus(true);
            }
            else
            {
                this._bidOrderStatus = OrderState.enUndefined;
                this.bidOrderStatusTextField.Text = string.Empty;
                UpdateButtonStatus(true);
            }
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Finished UpdateBidOrderStatus");
        }

        /// <summary>
        ///     Update status for ask order.
        /// </summary>
        private void UpdateAskOrderStatus()
        {
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Begin UpdateAskOrderStatus...");
            if (this._askOrder != null)
            {
                LogManager.Log(event_type.et_Internal, severity_type.st_info, string.Format("UpdateAskOrderStatus...{0}", this._askOrder.OrderState));
                this._askOrderStatus = this._askOrder.OrderState;
                this.askOrderStatusTextField.Text = this._askOrderStatus.ToStr();
                UpdateButtonStatus(false);
            }
            else
            {
                this._askOrderStatus = OrderState.enUndefined;
                this.askOrderStatusTextField.Text = string.Empty;
                UpdateButtonStatus(false);
            }
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Finished UpdateAskOrderStatus");
        }

        private void VolChanged(bool isBid)
        {
            var volSpin = isBid ? this.bidVolSpin : this.askVolSpin;
            decimal vol = 0;
            if (volSpin.EditValue == null || Decimal.TryParse(volSpin.EditValue.ToString(), out vol) == false)
            {
                return;
            }

            if (isBid)
            {
                this._isBidVolChange = false;
                if (this._bidOldVol != vol)
                {
                    this._bidVol = vol;
                    this._isBidVolChange = true;
                }
            }
            else
            {
                this._isAskVolChange = false;
                if (this._askOldVol != vol)
                {
                    this._askVol = vol;
                    this._isAskVolChange = true;
                }
            }

            UpdateButtonStatus(isBid);
        }

        private void DiffChanged(bool isBid)
        {
            var diffSpin = isBid ? this.bidDiffSpin : this.askDiffSpin;
            decimal diff = 0;
            if (diffSpin.EditValue == null || Decimal.TryParse(diffSpin.EditValue.ToString(), out diff) == false)
            {
                return;
            }

            if (isBid)
            {
                this._isBidDiffChange = false;
                if (this._bidOldDifferential != diff)
                {
                    this._bidDifferential = diff;
                    this._isBidDiffChange = true;
                }
            }
            else
            {
                this._isAskDiffChange = false;
                if (this._askOldDifferential != diff)
                {
                    this._askDifferential = diff;
                    this._isAskDiffChange = true;
                }
            }
            UpdateButtonStatus(isBid);
        }

        /// <summary>
        ///     Handle template change
        /// </summary>
        /// <param name="isBid"></param>
        private void SelectedTemplateChanged(bool isBid)
        {
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Begin SelectedTemplateChanged...");

            var templateLookUp = isBid ? this.bidTemplateLookUp : this.askTemplateLookUp;
            var diffSpin = isBid ? this.bidDiffSpin : this.askDiffSpin;
            var volSpin = isBid ? this.bidVolSpin : this.askVolSpin;
            var symbolTextField = isBid ? this.bidSymbolTextEdit : this.askSymbolTextEdit;
            var accountLookUp = isBid ? this.bidAccountLookUp : this.askAccountLookUp;

            var selectedItem = templateLookUp.EditValue as DynamicPostingTemplateDataItem;
            if (selectedItem == null)
            {
                return;
            }

            var accounts = new List<string>();
            accounts.Add(selectedItem.Account);
            accountLookUp.Properties.DataSource = accounts;
            accountLookUp.EditValue = selectedItem.Account;

            InstrumentBook instrument = null;
            for (var i = 0; i < Singleton<InstrumentBookCollection>.Instance.DynamicInstrumentBook.Count; i++)
            {
                if (Singleton<InstrumentBookCollection>.Instance.DynamicInstrumentBook[i].SecId != null)
                {
                    if (Singleton<InstrumentBookCollection>.Instance.DynamicInstrumentBook[i].SecId.SecId ==
                        selectedItem.NeoSecurityId.ToString())
                    {
                        instrument = Singleton<InstrumentBookCollection>.Instance.DynamicInstrumentBook[i];
                        break;
                    }
                }
            }

			//if (instrument == null)
			//{
			//    return;
			//}

            if (isBid)
            {
                this._bidTemplate = selectedItem;
                this._bidInstrument = instrument;

                if (this._isBidSelectedTemplate == false)
                {
                    this._isBidSelectedTemplate = true;
                    this.bidMinIncrementTextField.Enabled = true;
                    this.bidDiffSpin.Enabled = true;
                    this.bidVolSpin.Enabled = true;
                }
            }
            else
            {
                this._askTemplate = selectedItem;
                this._askInstrument = instrument;

                if (this._isAskSelectedTemplate == false)
                {
                    this._isAskSelectedTemplate = true;
                    this.askMinIncrementTextField.Enabled = true;
                    this.askDiffSpin.Enabled = true;
                    this.askVolSpin.Enabled = true;
                }
            }

            

            volSpin.EditValue = selectedItem.Volume;
            diffSpin.EditValue = selectedItem.Differential;
            symbolTextField.EditValue = selectedItem.NeoSymbol;
			UpdateButtonStatus(isBid);
			if (instrument == null)
			{
				if (isBid)
				{
					this.bidDiffSpin.Enabled = false;
					this.bidVolSpin.Enabled = false;
					this.bidMinIncrementTextField.Enabled = false;
					this.reBidButton.Enabled = false;
					this.bidCheckPriceButton.Enabled = false;
					this.bidCancelButton.Enabled = false;
				}
				else
				{
					this.askMinIncrementTextField.Enabled = false;
					this.askDiffSpin.Enabled = false;
					this.askVolSpin.Enabled = false;
					this.reAskButton.Enabled = false;
					this.askCheckPriceButton.Enabled = false;
					this.askCancelButton.Enabled = false;
				}
				return;
			}

			SetupFormatting(isBid);
            

            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Finished SelectedTemplateChanged");
        }

        /// <summary>
        ///     handle min increment changed -> update differential spin increment
        /// </summary>
        /// <param name="isBid"></param>
        private void MinIncrementChanged(bool isBid)
        {
            var minIncrement = isBid ? this.bidMinIncrementTextField : this.askMinIncrementTextField;
            var diffSpin = isBid ? this.bidDiffSpin : this.askDiffSpin;

            decimal incrementUnit;
            if (Decimal.TryParse(minIncrement.EditValue.ToString(), out incrementUnit) == false)
            {
                return;
            }

            diffSpin.Properties.Increment = incrementUnit;
        }

        /// <summary>
        ///     Validating min increment input (number & greater than zero)
        /// </summary>
        /// <param name="isBid"></param>
        /// <param name="e"></param>
        private void MinIncrementValidating(bool isBid, CancelEventArgs e)
        {
            var minIncrement = isBid ? this.bidMinIncrementTextField : this.askMinIncrementTextField;
            var instrument = isBid ? this._bidInstrument : this._askInstrument;

            decimal d;
            if (decimal.TryParse(minIncrement.Text, out d) == false)
            {
                e.Cancel = true;
                return;
            }
            if (d <= 0)
            {
                minIncrement.EditValue = (decimal) instrument.RealPrice(instrument.TickSize);
                return;
            }
        }

        /// <summary>
        ///     handle reBid/reAsk
        /// </summary>
        /// <param name="isBid"></param>
        private void ReOrder(bool isBid)
        {
            CreateOrder(isBid);
        }

        /// <summary>
        ///     handle new order
        /// </summary>
        /// <param name="isBid"></param>
        private void CreateOrder(bool isBid)
        {
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Begin CreateOrder...");

            var selectedTemplate = isBid ? this._bidTemplate : this._askTemplate;
            var diffSpin = isBid ? this.bidDiffSpin : this.askDiffSpin;
            var volSpin = isBid ? this.bidVolSpin : this.askVolSpin;
            var clOrdId = IdGenerator.GetUniqueId();
            double diff;
            int vol;
            double.TryParse(diffSpin.EditValue.ToString(), out diff);
            int.TryParse(volSpin.EditValue.ToString(), out vol);
            var orderStatus = isBid ? this._bidOrderStatus : this._askOrderStatus;

            bool isServiceAlive = true;

            try
            {
                if ((orderStatus == OrderState.enFilled || orderStatus == OrderState.enCanceled ||
                     orderStatus == OrderState.enUndefined))
                {
                    using (var dynamciPostingServiceClient = ServiceFactory.GetDynamicPostingServiceClient())
                    {
                        //Check if DynamicPostingService is available
                        if (Singleton<DynamicPostingController>.Instance.CheckDynamicPostingServiceAvailable())
                        {
	                        bool setActiveResult = dynamciPostingServiceClient.SetActive(Singleton<Settings>.Instance.user_name,
	                                                               selectedTemplate.Name,
	                                                               isBid ? 0 : 1,
	                                                               (long) (diff*selectedTemplate.Denominator), vol, clOrdId);
                            if (!setActiveResult)
                            {
                                XtraMessageBox.Show(this,
                                                    LocalizeManager.GetInfoMessage(InfoMessageClient.DynamicServerReturnsFalse), "Create Order",
                                                    MessageBoxButtons.OK);
                                var reOrderButton = isBid ? this.reBidButton : this.reAskButton;
                                reOrderButton.Enabled = true;
                                isServiceAlive = false;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(this,
                                                LocalizeManager.GetErrorMessage(ErrorMessageClient.DynamicTemplateCannotConnectToServer), "Create Order",
                                                MessageBoxButtons.OK);
                            var reOrderButton = isBid ? this.reBidButton : this.reAskButton;
                            reOrderButton.Enabled = true;
                            isServiceAlive = false;
                        }
                    }
                }
                else
                {
                    CancelOrder(isBid);
                    using (var dynamciPostingServiceClient = ServiceFactory.GetDynamicPostingServiceClient())
                    {
                        //Check if DynamicPostingService is available
                        if (Singleton<DynamicPostingController>.Instance.CheckDynamicPostingServiceAvailable())
                        {
                            if (
                                !dynamciPostingServiceClient.SetActive(Singleton<Settings>.Instance.user_name, selectedTemplate.Name,
                                                                       isBid ? 0 : 1,
                                                                       (long) (diff*selectedTemplate.Denominator), vol, clOrdId))
                            {
                                XtraMessageBox.Show(this,
                                                    LocalizeManager.GetInfoMessage(InfoMessageClient.DynamicServerReturnsFalse), "Create Order",
                                                    MessageBoxButtons.OK);
                                isServiceAlive = false;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show(this,
                                                LocalizeManager.GetErrorMessage(ErrorMessageClient.DynamicTemplateCannotConnectToServer), "Create Order",
                                                MessageBoxButtons.OK);
                            isServiceAlive = false;
                        }
                    }
                }
                if (isServiceAlive)
                {
                    if (isBid)
                    {
                        this._bidOrderStatus = OrderState.enNew;
                        this._bidOrdId = clOrdId;
                        this._isBidVolChange = false;
                        this._isBidDiffChange = false;
                        this._bidOldDifferential = this._bidDifferential;
                        this._bidOldVol = this._bidVol;
                    }
                    else
                    {
                        this._askOrderStatus = OrderState.enNew;
                        this._askOrdId = clOrdId;
                        this._isAskVolChange = false;
                        this._isAskDiffChange = false;
                        this._askOldDifferential = this._askDifferential;
                        this._askOldVol = this._askVol;
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Log(event_type.et_Internal, severity_type.st_error, ex.Message);
            }
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Finished CreateOrder");
        }

        /// <summary>
        ///     handle cancel order
        /// </summary>
        /// <param name="isBid"></param>
        private void CancelOrder(bool isBid)
        {
            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Begin CancelOrder");
            try
            {
                if (isBid)
                {
                    using (var dynamicPostingClient = ServiceFactory.GetDynamicPostingServiceClient())
                    {
                        if (Singleton<DynamicPostingController>.Instance.CheckDynamicPostingServiceAvailable())
                        {
                            dynamicPostingClient.Cancel(this._bidOrdId);
                        }
                        else
                        {
                            XtraMessageBox.Show(this,
                                                LocalizeManager.GetErrorMessage(ErrorMessageClient.DynamicTemplateCannotConnectToServer), "Cancel Order",
                                                MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    using (var dynamicPostingClient = ServiceFactory.GetDynamicPostingServiceClient())
                    {
                        if (Singleton<DynamicPostingController>.Instance.CheckDynamicPostingServiceAvailable())
                        {
                            dynamicPostingClient.Cancel(this._askOrdId);
                        }
                        else
                        {
                            XtraMessageBox.Show(this,
                                                LocalizeManager.GetErrorMessage(ErrorMessageClient.DynamicTemplateCannotConnectToServer), "Cancel Order",
                                                MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LogManager.Log(event_type.et_Internal, severity_type.st_error, exception.Message);
            }

            LogManager.Log(event_type.et_Internal, severity_type.st_info, "Finished CancelOrder");
        }

        /// <summary>
        ///     Check price (call GetTestPrice in DynamicPostingSerivce)
        /// </summary>
        /// <param name="isBid"></param>
        private void CheckPrice(bool isBid)
        {
            var selectedTemplate = isBid ? this._bidTemplate : this._askTemplate;
            var diffSpin = isBid ? this.bidDiffSpin : this.askDiffSpin;
            var volSpin = isBid ? this.bidVolSpin : this.askVolSpin;
            try
            {
                double diff;
                int vol;
                double.TryParse(diffSpin.EditValue.ToString(), out diff);
                int.TryParse(volSpin.EditValue.ToString(), out vol);

                int? price = null;

                using (var dynamicPostingServiceClient = ServiceFactory.GetDynamicPostingServiceClient())
                {
                    if (Singleton<DynamicPostingController>.Instance.CheckDynamicPostingServiceAvailable())
                    {
                        price = dynamicPostingServiceClient.GetTestPrice(Singleton<Settings>.Instance.user_name, selectedTemplate.Name,
                                                                         (long) (diff*selectedTemplate.Denominator), vol);

                        //Unscale price
                        if (price.HasValue)
                        {
                            var realPrice = ((price.Value)/(decimal) (selectedTemplate.Denominator));
                            XtraMessageBox.Show(this, string.Format("Price: {0:N2}", realPrice), "Check Price",
                                                MessageBoxButtons.OK);
                        }
                        else
                        {
                            XtraMessageBox.Show(this,
                                                LocalizeManager.GetInfoMessage(InfoMessageClient.DynamicServerReturnsFalse), "Check Price", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(this,
                                            LocalizeManager.GetErrorMessage(ErrorMessageClient.DynamicTemplateCannotConnectToServer), "Check Price",
                                            MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception exception)
            {
                LogManager.Log(event_type.et_Internal, severity_type.st_error, exception.Message);
                LogManager.Log(event_type.et_Internal, severity_type.st_error, exception.StackTrace);
            }
        }

        /// <summary>
        ///     setup format for MinIncrement, Differential, Volumn
        /// </summary>
        /// <param name="isBid"></param>
        private void SetupFormatting(bool isBid)
        {
            var minIncrementTextField = isBid ? this.bidMinIncrementTextField : this.askMinIncrementTextField;
            var diffSpin = isBid ? this.bidDiffSpin : this.askDiffSpin;
            var instrument = isBid ? this._bidInstrument : this._askInstrument;

            minIncrementTextField.Properties.DisplayFormat.Format = new PriceFormatter(instrument);
            minIncrementTextField.Properties.EditFormat.FormatType = FormatType.Custom;
            minIncrementTextField.Properties.EditFormat.FormatString = "w";
            minIncrementTextField.Properties.EditFormat.Format = new PriceFormatter(instrument);
            minIncrementTextField.EditValue = (decimal) instrument.RealPrice(instrument.TickSize);
            minIncrementTextField.Properties.ValidateOnEnterKey = true;

            diffSpin.Properties.DisplayFormat.FormatType = FormatType.Custom;
            diffSpin.Properties.DisplayFormat.Format = new PriceFormatter(instrument);
            diffSpin.Properties.EditFormat.FormatType = FormatType.Custom;
            diffSpin.Properties.EditFormat.FormatString = "w";
            diffSpin.Properties.EditFormat.Format = new PriceFormatter(instrument);

            if (instrument.IsNeedQuotation)
            {
                minIncrementTextField.Properties.Mask.MaskType = MaskType.RegEx;
                minIncrementTextField.Properties.Mask.EditMask = "[0-9]+";

                diffSpin.Properties.Mask.MaskType = MaskType.RegEx;
                diffSpin.Properties.Mask.EditMask = "[0-9]+";
            }
            else
            {
                minIncrementTextField.Properties.Mask.MaskType = MaskType.Numeric;
                minIncrementTextField.Properties.Mask.EditMask = instrument.PrFmt;

                diffSpin.Properties.Mask.MaskType = MaskType.Numeric;
                diffSpin.Properties.EditMask = instrument.PrFmt;
            }
        }

        /// <summary>
        ///     Update button status (CheckPrice,ReBid/ReAsk,Bid/Ask,Cancel)
        /// </summary>
        /// <param name="isBid"></param>
        private void UpdateButtonStatus(bool isBid)
        {
            var isSelectedTemplate = isBid ? this._isBidSelectedTemplate : this._isAskSelectedTemplate;
            var isVolChange = isBid ? this._isBidVolChange : this._isAskVolChange;
            var isDiffChange = isBid ? this._isBidDiffChange : this._isAskDiffChange;
            var orderStatus = isBid ? this._bidOrderStatus : this._askOrderStatus;

            var checkPriceButton = isBid ? this.bidCheckPriceButton : this.askCheckPriceButton;
            var reOrderButton = isBid ? this.reBidButton : this.reAskButton;
            var cancelOrderButton = isBid ? this.bidCancelButton : this.askCancelButton;

            var isHasChange = isVolChange || isDiffChange;
	        var instrument = isBid ? this._bidInstrument : this._askInstrument;

            if (isSelectedTemplate)
            {
				if(instrument!=null)
					checkPriceButton.Enabled = true;
				else
					checkPriceButton.Enabled = false;
            }
            else
            {
                checkPriceButton.Enabled = false;
            }

            if (isSelectedTemplate &&
                (orderStatus == OrderState.enFilled || orderStatus == OrderState.enCanceled || orderStatus == OrderState.enUndefined) ||
                (isSelectedTemplate && isHasChange))
            {

				if (instrument == null)
				{
					reOrderButton.Enabled = false;
				}
				else
					reOrderButton.Enabled = (isBid ? Singleton<DynamicPostingController>.Instance.DisplayDataItems.Contains(this._bidTemplate) : Singleton<DynamicPostingController>.Instance.DisplayDataItems.Contains(this._askTemplate))
                                        && (isBid ? this.bidVolSpin.Value > 0 : this.askVolSpin.Value > 0);

            }
            else
            {
                reOrderButton.Enabled = false;
            }

            if (orderStatus == OrderState.enNew || orderStatus == OrderState.enPartiallyFilled || orderStatus == OrderState.enReplaceAccepted 
                || orderStatus == OrderState.enPendingCanceled || orderStatus == OrderState.enPendingReplaced)
            {
				if (instrument == null && isSelectedTemplate )
					cancelOrderButton.Enabled = false;
				else
					cancelOrderButton.Enabled = true;
            }
            else
            {
                cancelOrderButton.Enabled = false;
            }
        }

        private void BidTemplateLookUpEditValueChanged(object sender, EventArgs e)
        {
            if (!Singleton<DynamicPostingController>.Instance.DisplayDataItems.Contains(this._bidTemplate))
            {
                this.reBidButton.Enabled = false;
            }
        }

        private void AskTemplateLookUpEditValueChanged(object sender, EventArgs e)
        {
            if (!Singleton<DynamicPostingController>.Instance.DisplayDataItems.Contains(this._askTemplate))
            {
                this.reAskButton.Enabled = false;
            }
        }

        private void BidVolSpinValueChanged(object sender, EventArgs e)
        {
            if (this.bidVolSpin.Value <= 0)
            {
                this.reBidButton.Enabled = false;
            }
        }

        private void askVolSpin_EditValueChanged(object sender, EventArgs e)
        {
            if (this.askVolSpin.Value <= 0)
            {
                this.reAskButton.Enabled = false;
            }
        }
    }
}