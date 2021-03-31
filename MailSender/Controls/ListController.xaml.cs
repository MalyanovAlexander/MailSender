using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для ListController.xaml
    /// </summary>
    public partial class ListController : UserControl
    {
        #region items property
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items", 
            typeof(IEnumerable), 
            typeof(ListController), 
            new PropertyMetadata(default(IEnumerable), OnItemsChanged, ItemsCoerceValue),
            ItemsValidate);

        private static bool ItemsValidate(object value)
        {
            return true; ;
        }

        private static void OnItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private static object ItemsCoerceValue(DependencyObject d, object baseValue)
        {
            return baseValue;
        }
        
        public IEnumerable Items
        {
            get => (IEnumerable)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }
        #endregion

        #region SelectedItem : object - Выбранный элемент
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            nameof(SelectedItem),
            typeof(object),
            typeof(ListController),
            new PropertyMetadata(default(object)));

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        private object SelectedItem
        {
            get => (object)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }
        #endregion

        #region PanelName : string - Название панели
        public static readonly DependencyProperty PanelItemProperty = DependencyProperty.Register(
            nameof(PanelName),
            typeof(string),
            typeof(ListController),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// Название панели
        /// </summary>
        private string PanelName
        {
            get => (string)GetValue(PanelItemProperty);
            set => SetValue(PanelItemProperty, value);
        }
        #endregion

        #region SelectedItemIndex : int - Индекс выбранного элемента
        public static readonly DependencyProperty SelectedItemIndexProperty = DependencyProperty.Register(
            nameof(SelectedItemIndex),
            typeof(int),
            typeof(ListController),
            new PropertyMetadata(default(int)));

        /// <summary>
        /// Индекс выбранного элемента
        /// </summary>
        private int SelectedItemIndex
        {
            get => (int)GetValue(SelectedItemIndexProperty);
            set => SetValue(SelectedItemIndexProperty, value);
        }
        #endregion

        #region SelectedItem : string - Имя отображаемого свойства
        public static readonly DependencyProperty ViewPropertyPathProperty = DependencyProperty.Register(
            nameof(ViewPropertyPath),
            typeof(string),
            typeof(ListController),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// Имя отображаемого свойства
        /// </summary>
        private string ViewPropertyPath
        {
            get => (string)GetValue(ViewPropertyPathProperty);
            set => SetValue(ViewPropertyPathProperty, value);
        }
        #endregion

        #region ValuePropertyPath : string - Имя свойства-значения
        public static readonly DependencyProperty ValuePropertyPathProperty = DependencyProperty.Register(
            nameof(ValuePropertyPath),
            typeof(string),
            typeof(ListController),
            new PropertyMetadata(default(string)));

        /// <summary>
        /// Имя свойства-значения
        /// </summary>
        private string ValuePropertyPath
        {
            get => (string)GetValue(ValuePropertyPathProperty);
            set => SetValue(ValuePropertyPathProperty, value);
        }
        #endregion

        #region Команды
        #region CreateCommand : ICommand - Команда создания нового значения
        public static readonly DependencyProperty CreateCommandProperty = DependencyProperty.Register(
            nameof(CreateCommand),
            typeof(ICommand),
            typeof(ListController),
            new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Команда создания нового значения
        /// </summary>
        private ICommand CreateCommand
        {
            get => (ICommand)GetValue(CreateCommandProperty);
            set => SetValue(CreateCommandProperty, value);
        }
        #endregion

        #region EditCommand : ICommand - Редактирование элемента
        public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register(
            nameof(EditCommand),
            typeof(ICommand),
            typeof(ListController),
            new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Редактирование элемента
        /// </summary>
        private ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }
        #endregion

        #region DeleteCommand : ICommand - Команда удаления элемента
        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register(
            nameof(DeleteCommand),
            typeof(ICommand),
            typeof(ListController),
            new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Команда удаления элемента
        /// </summary>
        private ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }
        #endregion
        #endregion

        public ListController() => InitializeComponent();
    }
}
