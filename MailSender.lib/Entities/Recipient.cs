using MailSender.lib.Entities.Base;
using System;
using System.ComponentModel;

namespace MailSender.lib.Entities
{
    public class Recipient : HumanEntity, IDataErrorInfo
    {
        public override string Name
        {
            get => base.Name;
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                if (value.Length <= 3) throw new ArgumentOutOfRangeException(nameof(value), "Имя должно быть не короче 3 символов");
                base.Name = value;
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    default: return string.Empty;

                    case nameof(Name):
                        //if (Name is null) return "Отсутствует ссылка на строку с именем";
                        //if (Name.Length <= 3) return "Имя должно быть не короче 3 символов";
                        if (!char.IsLetter(Name[0])) return "Имя должно начинаться с буквы";
                        return string.Empty;
                }
            }
        }

       

        string IDataErrorInfo.Error => throw new System.NotImplementedException();
    }
}
