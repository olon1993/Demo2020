using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.ViewModels
{
    public class MagicItemViewModel : ObservableObject, IMagicItemViewModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private bool _isDebugOn = false;

        private IMagicItemFactoryService _magicItemFactory;
        private IMagicItemDataAccessService _magicItemDataAccessObject;
        private IMagicItemSearchAndFilterService _magicItemSearchAndFilter;
        private IMagicItemModel _CurrentMagicItem;
        private IList<IMagicItemModel> _magicItems;
        private IList<IMagicItemModel> _magicItemsRaw;
        private string _filter = "";
        private int _SelectedMagicItemIndex = -1;

        public MagicItemViewModel(IMagicItemFactoryService magicItemFactory, IMagicItemDataAccessService magicItemDataAccessObject, IMagicItemSearchAndFilterService magicItemSearchAndFilter)
        {
            _magicItemFactory = magicItemFactory;
            _magicItemDataAccessObject = magicItemDataAccessObject;
            _magicItemSearchAndFilter = magicItemSearchAndFilter;

            Messenger.Default.Register<MessageWindowResponse>(this, "ReloadMonster", msg =>
            {
                if (msg.Response)
                {
                    GetMagicItemDetails();
                }
            });

            GetMagicItems();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetMagicItems()
        {
            _magicItemsRaw = MagicItems = (await _magicItemDataAccessObject.GetAllMagicItems())
                .Cast<IMagicItemModel>()
                .ToList() as IList<IMagicItemModel>;

            if (_isDebugOn)
            {
                foreach (IMagicItemModel magicItem in MagicItems)
                {
                    Console.WriteLine(magicItem.Name);
                }
            }
        }

        private async void GetMagicItemDetails()
        {
            CurrentMagicItem = MagicItems[SelectedMagicItemIndex];
            if (CurrentMagicItem.IsDataComplete == false)
            {
                MagicItems[SelectedMagicItemIndex] = (await _magicItemDataAccessObject.GetMagicItem(MagicItems[SelectedMagicItemIndex].Name)) as IMagicItemModel;

                // The monster api failed and returned null
                if (MagicItems[SelectedMagicItemIndex] == null)
                {
                    MagicItems[SelectedMagicItemIndex] = CurrentMagicItem;
                    Messenger.Default.Send(new MessageWindowConfiguration
                    {
                        Message = "An error occurred while getting " + CurrentMagicItem.Name + " data. Would you like to try again? " +
                        "Check you internet connection if you continue to see this message.",
                        IsOkVisible = false,
                        IsTrueFalseVisible = true,
                        Token = "ReloadMonster"
                    });
                }
                else
                {
                    MagicItems[SelectedMagicItemIndex].IsDataComplete = true;
                    CurrentMagicItem = MagicItems[SelectedMagicItemIndex];
                }
            }

            if (_isDebugOn)
            {
                Console.Write(CurrentMagicItem.EquipmentCategory.Name);
            }
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public int SelectedMagicItemIndex
        {
            get { return _SelectedMagicItemIndex; }
            set
            {
                if (_SelectedMagicItemIndex != value)
                {
                    _SelectedMagicItemIndex = value;
                    if (_SelectedMagicItemIndex > -1)
                    {
                        GetMagicItemDetails();
                    }
                    OnPropertyChanged();
                }
            }
        }

        public IMagicItemModel CurrentMagicItem
        {
            get { return _CurrentMagicItem; }
            set
            {
                if (_CurrentMagicItem != value)
                {
                    _CurrentMagicItem = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<IMagicItemModel> MagicItems
        {
            get { return _magicItems; }
            set
            {
                if (_magicItems != value)
                {
                    _magicItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    MagicItems = _magicItemSearchAndFilter.Filter(_magicItemsRaw, _filter);
                    OnPropertyChanged();
                }
            }
        }
    }
}
