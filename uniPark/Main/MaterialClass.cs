using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin;
using MaterialSkin.Controls;
using MaterialSkin.Animations;

namespace uniPark.Main
{
    public static class MaterialClass
    {

        public static void material(MaterialForm frm)
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(frm);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Green800,
                Primary.Green900,
                Primary.Green500,
                Accent.Green200,
                TextShade.WHITE);       }
    }
}
