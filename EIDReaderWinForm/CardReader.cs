// Decompiled with JetBrains decompiler
// Type: EIDReaderForSAP.CardReader
// Assembly: EIDReaderForSAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D226410D-D631-4893-A417-67A5726464ED
// Assembly location: C:\EIDReaderForSAP\EIDReaderForSAP.exe

using EIDNative;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EIDReaderWinForm
{
    internal class CardReader
    {
        private static string exportDir = "c:/temp";
        private static string currentPhoto = "/currentphoto.jpg";
        private static string currentIdentity = "/currentidentity";
        public static EIDCard eidCard;

        public CardReader(string card)
        {
            eidCard = null;
            if (CardReader.eidCard == null)
            {
                CardReader.InitReader();
                //CardReader.deleteData();
            }
            string[] array = EIDCard.ListReaders();
            string storedCard = card;
            if (storedCard.Length > 0 && array != null)
            {
                int index = Array.FindIndex<string>(array, (Predicate<string>)(reader => reader.Equals(storedCard)));
                CardReader.eidCard.SelectReader(index);
            }
            else
                CardReader.eidCard.SelectReader(0);

            //CardReader.eidCard.ReadId();
            //CardReader.eidCard.ReadSisId();
            //CardReader.eidCard.ReadPicture();
            CardReader.ReadCardData();
        }

        public static void InitReader()
        {
            CardReader.eidCard = new EIDCard();
            CardReader.eidCard.InitReader(false);
            CardReader.eidCard.CardInvalid += new EventHandler(CardReader.eidCard_CardInvalid);
            CardReader.eidCard.CardInserted += new EventHandler(CardReader.eidCard_CardInserted);
            CardReader.eidCard.CardError += new EventHandler<EIDErrorEventArgs>(CardReader.eidCard_CardError);
            CardReader.eidCard.CardRemoved += new EventHandler(CardReader.eidCard_CardRemoved);
            CardReader.eidCard.CardActivated += new EventHandler(CardReader.eidCard_CardActivated);
            CardReader.eidCard.CardWaiting += new EventHandler(CardReader.eidCard_CardWaiting);
        }

        private static void ReadCardData()
        {
            GC.Collect();
            //string str1 = "";
            //string str2 = "";
            if (CardReader.eidCard.ReadId())
            {
                //string str3 = CardReader.eidCard.Address.Street.Trim();
                //int startIndex = str3.Length - 1;
                //while (startIndex > 0)
                //{
                //    if ((int)str3[startIndex] == 32)
                //    {
                //        if ((int)str3[startIndex + 1] == 47)
                //        {
                //            str2 = str3.Substring(startIndex + 2, str3.Length - startIndex - 2);
                //            str3 = str3.Remove(startIndex, str3.Length - startIndex);
                //            --startIndex;
                //        }
                //        else
                //        {
                //            str1 = str3.Substring(startIndex + 1, str3.Length - startIndex - 1);
                //            str3 = str3.Remove(startIndex, str3.Length - startIndex);
                //            break;
                //        }
                //    }
                //    else
                //        --startIndex;
                //}
                //Directory.CreateDirectory(CardReader.exportDir);
                if (CardReader.eidCard.ReadPicture())
                {
                    //try
                    //{
                    //    new Bitmap(CardReader.eidCard.Picture).Save(CardReader.exportDir + CardReader.currentPhoto, ImageFormat.Jpeg);
                    //}
                    //catch (Exception ex)
                    //{
                    //}
                }
                //using (CsvFileWriter csvFileWriter = new CsvFileWriter(CardReader.exportDir + CardReader.currentIdentity))
                //{
                //    CsvRow row = new CsvRow();
                //    row.Add(str3);
                //    row.Add(str1);
                //    row.Add(str2);
                //    row.Add(CardDate.ToShortDateString(CardReader.eidCard.Identity.BirthDate));
                //    row.Add(CardReader.eidCard.Identity.BirthLocation);
                //    row.Add(CardNumber.ToString(CardReader.eidCard.Identity.CardNumber));
                //    row.Add(DocumentType.ToString(CardReader.eidCard.Identity.DocumentType));
                //    row.Add(CardReader.eidCard.Identity.ChipNumber);
                //    row.Add(CardReader.eidCard.Address.Municipality);
                //    row.Add(CardReader.eidCard.Identity.FirstName1);
                //    row.Add(CardReader.eidCard.Identity.Surname);
                //    row.Add(CardReader.eidCard.Identity.Municipality);
                //    row.Add(CardReader.eidCard.Identity.Nationality);
                //    row.Add(NationalNumber.ToString(CardReader.eidCard.Identity.NationalNumber));
                //    row.Add(CardReader.eidCard.Identity.Sex);
                //    row.Add(CardDate.ToShortDateString(CardReader.eidCard.Identity.ValidityDateBegin));
                //    row.Add(CardDate.ToShortDateString(CardReader.eidCard.Identity.ValidityDateEnd));
                //    row.Add(CardReader.eidCard.Address.Zip);
                //    row.Add(CardReader.eidCard.Identity.NationalityISO);
                //    csvFileWriter.WriteRow(row);
                //}
            }
            else
            {
                //int num = (int)MessageBox.Show("Can not read EID card");
            }
            GC.Collect();
        }

        private static void deleteData()
        {
            if (File.Exists(CardReader.exportDir + CardReader.currentIdentity))
                File.Delete(CardReader.exportDir + CardReader.currentIdentity);
            if (!File.Exists(CardReader.exportDir + CardReader.currentPhoto))
                return;
            File.Delete(CardReader.exportDir + CardReader.currentPhoto);
        }

        private static void eidCard_CardActivated(object sender, EventArgs e)
        {
        }

        private static void eidCard_CardInserted(object sender, EventArgs e)
        {
            //new ProcessIcon().getNotifyIcon().Icon = Resources.beid;
            CardReader.ReadCardData();
        }

        private static void eidCard_CardRemoved(object sender, EventArgs e)
        {
            //new ProcessIcon().getNotifyIcon().Icon = Resources.beid_grey;
            CardReader.deleteData();
        }

        private static void eidCard_CardWaiting(object sender, EventArgs e)
        {
        }

        private static void eidCard_CardInvalid(object sender, EventArgs e)
        {
        }

        private static void eidCard_CardError(object sender, EIDErrorEventArgs e)
        {
        }
    }
}
