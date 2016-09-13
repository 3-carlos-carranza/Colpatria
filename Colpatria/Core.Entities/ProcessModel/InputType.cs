#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=InputType.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-26  - 11:03 a. m.</Date>
//   <Update> 2016-08-26 - 11:03 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

namespace Core.Entities.ProcessModel
{
    public enum InputType
    {
        Number = 0,
        Text = 1,
        Email = 2,
        Phone = 3,
        DateTime = 4,
        Date = 5,
        List = 6,
        Checkbox = 7,
        Radio = 8,
        Url = 9,
        Alphanumeric = 10,
        MobilePhone = 11,
        File = 12,
        Hidden = 13,
        Money = 14,
        Search = 15,
        Password = 16,
        CheckList = 17,
        Label = 18,
        LabelText = 19,
        LabelDate = 20,
        LabelList = 21,
        LabelMail = 22
    }
}