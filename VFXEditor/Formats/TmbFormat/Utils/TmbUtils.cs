using System;
using System.Collections.Generic;
using VfxEditor.TmbFormat.Entries;

namespace VfxEditor.TmbFormat.Utils {
    public struct ItemTypeStruct {
        public string DisplayName;
        public Type Type;

        public ItemTypeStruct( string displayName, Type type ) {
            DisplayName = displayName;
            Type = type;
        }
    }

    public class TmbUtils {
        public static readonly SortedDictionary<string, ItemTypeStruct> ItemTypes = new() {
            { C002.MAGIC, new ItemTypeStruct( C002.DISPLAY_NAME, typeof(C002) ) },
            { C004.MAGIC, new ItemTypeStruct( C004.DISPLAY_NAME, typeof(C004) ) },
            { C005.MAGIC, new ItemTypeStruct( C005.DISPLAY_NAME, typeof(C005) ) }, //FAFO
            { C006.MAGIC, new ItemTypeStruct( C006.DISPLAY_NAME, typeof(C006) ) },
            { C007.MAGIC, new ItemTypeStruct( C007.DISPLAY_NAME, typeof(C007) ) }, //FAFO
            { C008.MAGIC, new ItemTypeStruct( C008.DISPLAY_NAME, typeof(C008) ) }, //FAFO
            { C009.MAGIC, new ItemTypeStruct( C009.DISPLAY_NAME, typeof(C009) ) },
            { C010.MAGIC, new ItemTypeStruct( C010.DISPLAY_NAME, typeof(C010) ) },
            { C011.MAGIC, new ItemTypeStruct( C011.DISPLAY_NAME, typeof(C011) ) },
            { C012.MAGIC, new ItemTypeStruct( C012.DISPLAY_NAME, typeof(C012) ) },
            { C013.MAGIC, new ItemTypeStruct( C013.DISPLAY_NAME, typeof(C013) ) },
            { C014.MAGIC, new ItemTypeStruct( C014.DISPLAY_NAME, typeof(C014) ) },
            { C015.MAGIC, new ItemTypeStruct( C015.DISPLAY_NAME, typeof(C015) ) },
            { C016.MAGIC, new ItemTypeStruct( C016.DISPLAY_NAME, typeof(C016) ) },
            { C017.MAGIC, new ItemTypeStruct( C017.DISPLAY_NAME, typeof(C017) ) }, //FAFO
            { C018.MAGIC, new ItemTypeStruct( C018.DISPLAY_NAME, typeof(C018) ) },
            { C019.MAGIC, new ItemTypeStruct( C019.DISPLAY_NAME, typeof(C019) ) },
            { C020.MAGIC, new ItemTypeStruct( C020.DISPLAY_NAME, typeof(C020) ) },
            { C021.MAGIC, new ItemTypeStruct( C021.DISPLAY_NAME, typeof(C021) ) },
            { C022.MAGIC, new ItemTypeStruct( C022.DISPLAY_NAME, typeof(C022) ) }, //FAFO
            { C023.MAGIC, new ItemTypeStruct( C023.DISPLAY_NAME, typeof(C023) ) }, //FAFO
            { C026.MAGIC, new ItemTypeStruct( C026.DISPLAY_NAME, typeof(C026) ) },
            { C031.MAGIC, new ItemTypeStruct( C031.DISPLAY_NAME, typeof(C031) ) },
            { C032.MAGIC, new ItemTypeStruct( C032.DISPLAY_NAME, typeof(C032) ) }, //FAFO
            { C033.MAGIC, new ItemTypeStruct( C033.DISPLAY_NAME, typeof(C033) ) },
            { C034.MAGIC, new ItemTypeStruct( C034.DISPLAY_NAME, typeof(C034) ) },
            { C035.MAGIC, new ItemTypeStruct( C035.DISPLAY_NAME, typeof(C035) ) },
            { C036.MAGIC, new ItemTypeStruct( C036.DISPLAY_NAME, typeof(C036) ) },
            { C037.MAGIC, new ItemTypeStruct( C037.DISPLAY_NAME, typeof(C037) ) },
            { C038.MAGIC, new ItemTypeStruct( C038.DISPLAY_NAME, typeof(C038) ) },
            { C040.MAGIC, new ItemTypeStruct( C040.DISPLAY_NAME, typeof(C040) ) },
            { C042.MAGIC, new ItemTypeStruct( C042.DISPLAY_NAME, typeof(C042) ) },
            { C043.MAGIC, new ItemTypeStruct( C043.DISPLAY_NAME, typeof(C043) ) },
            { C044.MAGIC, new ItemTypeStruct( C044.DISPLAY_NAME, typeof(C044) ) },
            { C045.MAGIC, new ItemTypeStruct( C045.DISPLAY_NAME, typeof(C045) ) },
            { C047.MAGIC, new ItemTypeStruct( C047.DISPLAY_NAME, typeof(C047) ) },
            { C048.MAGIC, new ItemTypeStruct( C048.DISPLAY_NAME, typeof(C048) ) },
            { C049.MAGIC, new ItemTypeStruct( C049.DISPLAY_NAME, typeof(C049) ) },
            { C050.MAGIC, new ItemTypeStruct( C050.DISPLAY_NAME, typeof(C050) ) },
            { C051.MAGIC, new ItemTypeStruct( C051.DISPLAY_NAME, typeof(C051) ) },
            { C053.MAGIC, new ItemTypeStruct( C053.DISPLAY_NAME, typeof(C053) ) },
            { C054.MAGIC, new ItemTypeStruct( C054.DISPLAY_NAME, typeof(C054) ) },
            { C055.MAGIC, new ItemTypeStruct( C055.DISPLAY_NAME, typeof(C055) ) },
            { C056.MAGIC, new ItemTypeStruct( C056.DISPLAY_NAME, typeof(C056) ) },
            { C057.MAGIC, new ItemTypeStruct( C057.DISPLAY_NAME, typeof(C057) ) },
            { C058.MAGIC, new ItemTypeStruct( C058.DISPLAY_NAME, typeof(C058) ) },
            { C059.MAGIC, new ItemTypeStruct( C059.DISPLAY_NAME, typeof(C059) ) },
            { C060.MAGIC, new ItemTypeStruct( C060.DISPLAY_NAME, typeof(C060) ) }, //FAFO
            { C061.MAGIC, new ItemTypeStruct( C061.DISPLAY_NAME, typeof(C061) ) }, //FAFO
            { C062.MAGIC, new ItemTypeStruct( C062.DISPLAY_NAME, typeof(C062) ) }, //FAFO
            { C063.MAGIC, new ItemTypeStruct( C063.DISPLAY_NAME, typeof(C063) ) },
            { C064.MAGIC, new ItemTypeStruct( C064.DISPLAY_NAME, typeof(C064) ) },
            { C065.MAGIC, new ItemTypeStruct( C065.DISPLAY_NAME, typeof(C065) ) },
            { C066.MAGIC, new ItemTypeStruct( C066.DISPLAY_NAME, typeof(C066) ) },
            { C067.MAGIC, new ItemTypeStruct( C067.DISPLAY_NAME, typeof(C067) ) },
            { C068.MAGIC, new ItemTypeStruct( C068.DISPLAY_NAME, typeof(C068) ) },
            { C069.MAGIC, new ItemTypeStruct( C069.DISPLAY_NAME, typeof(C069) ) },
            { C070.MAGIC, new ItemTypeStruct( C070.DISPLAY_NAME, typeof(C070) ) },
            { C071.MAGIC, new ItemTypeStruct( C071.DISPLAY_NAME, typeof(C156) ) },
            { C072.MAGIC, new ItemTypeStruct( C072.DISPLAY_NAME, typeof(C072) ) },
            { C073.MAGIC, new ItemTypeStruct( C073.DISPLAY_NAME, typeof(C073) ) },
            { C074.MAGIC, new ItemTypeStruct( C074.DISPLAY_NAME, typeof(C074) ) }, //FAFO
            { C075.MAGIC, new ItemTypeStruct( C075.DISPLAY_NAME, typeof(C075) ) },
            { C077.MAGIC, new ItemTypeStruct( C077.DISPLAY_NAME, typeof(C077) ) },
            { C081.MAGIC, new ItemTypeStruct( C081.DISPLAY_NAME, typeof(C081) ) },
            { C082.MAGIC, new ItemTypeStruct( C082.DISPLAY_NAME, typeof(C082) ) },
            { C083.MAGIC, new ItemTypeStruct( C083.DISPLAY_NAME, typeof(C083) ) },
            { C084.MAGIC, new ItemTypeStruct( C084.DISPLAY_NAME, typeof(C084) ) },
            { C085.MAGIC, new ItemTypeStruct( C085.DISPLAY_NAME, typeof(C085) ) },
            { C087.MAGIC, new ItemTypeStruct( C087.DISPLAY_NAME, typeof(C087) ) },
            { C088.MAGIC, new ItemTypeStruct( C088.DISPLAY_NAME, typeof(C088) ) },
            { C089.MAGIC, new ItemTypeStruct( C089.DISPLAY_NAME, typeof(C089) ) },
            { C090.MAGIC, new ItemTypeStruct( C090.DISPLAY_NAME, typeof(C090) ) },
            { C091.MAGIC, new ItemTypeStruct( C091.DISPLAY_NAME, typeof(C091) ) },
            { C092.MAGIC, new ItemTypeStruct( C092.DISPLAY_NAME, typeof(C092) ) },
            { C093.MAGIC, new ItemTypeStruct( C093.DISPLAY_NAME, typeof(C093) ) },
            { C094.MAGIC, new ItemTypeStruct( C094.DISPLAY_NAME, typeof(C094) ) },
            { C095.MAGIC, new ItemTypeStruct( C095.DISPLAY_NAME, typeof(C095) ) },
            { C096.MAGIC, new ItemTypeStruct( C096.DISPLAY_NAME, typeof(C096) ) },
            { C097.MAGIC, new ItemTypeStruct( C097.DISPLAY_NAME, typeof(C097) ) },
            { C098.MAGIC, new ItemTypeStruct( C098.DISPLAY_NAME, typeof(C098) ) },
            { C099.MAGIC, new ItemTypeStruct( C099.DISPLAY_NAME, typeof(C099) ) },
            { C100.MAGIC, new ItemTypeStruct( C100.DISPLAY_NAME, typeof(C100) ) },
            { C101.MAGIC, new ItemTypeStruct( C101.DISPLAY_NAME, typeof(C101) ) }, //FAFO
            { C102.MAGIC, new ItemTypeStruct( C102.DISPLAY_NAME, typeof(C102) ) }, //FAFO
            { C103.MAGIC, new ItemTypeStruct( C103.DISPLAY_NAME, typeof(C103) ) },
            { C104.MAGIC, new ItemTypeStruct( C104.DISPLAY_NAME, typeof(C104) ) },
            { C105.MAGIC, new ItemTypeStruct( C105.DISPLAY_NAME, typeof(C105) ) }, //FAFO
            { C106.MAGIC, new ItemTypeStruct( C106.DISPLAY_NAME, typeof(C106) ) }, //FAFO
            { C107.MAGIC, new ItemTypeStruct( C107.DISPLAY_NAME, typeof(C107) ) },
            { C108.MAGIC, new ItemTypeStruct( C108.DISPLAY_NAME, typeof(C108) ) }, //FAFO
            { C109.MAGIC, new ItemTypeStruct( C109.DISPLAY_NAME, typeof(C109) ) },
            { C110.MAGIC, new ItemTypeStruct( C110.DISPLAY_NAME, typeof(C110) ) },
            { C111.MAGIC, new ItemTypeStruct( C111.DISPLAY_NAME, typeof(C111) ) }, //FAFO
            { C112.MAGIC, new ItemTypeStruct( C112.DISPLAY_NAME, typeof(C112) ) },
            { C113.MAGIC, new ItemTypeStruct( C113.DISPLAY_NAME, typeof(C113) ) },
            { C114.MAGIC, new ItemTypeStruct( C114.DISPLAY_NAME, typeof(C114) ) },
            { C115.MAGIC, new ItemTypeStruct( C115.DISPLAY_NAME, typeof(C115) ) }, //FAFO
            { C116.MAGIC, new ItemTypeStruct( C116.DISPLAY_NAME, typeof(C116) ) }, //FAFO
            { C117.MAGIC, new ItemTypeStruct( C117.DISPLAY_NAME, typeof(C117) ) },
            { C118.MAGIC, new ItemTypeStruct( C118.DISPLAY_NAME, typeof(C118) ) },
            { C119.MAGIC, new ItemTypeStruct( C119.DISPLAY_NAME, typeof(C119) ) }, //FAFO
            { C120.MAGIC, new ItemTypeStruct( C120.DISPLAY_NAME, typeof(C120) ) },
            { C121.MAGIC, new ItemTypeStruct( C121.DISPLAY_NAME, typeof(C121) ) }, //FAFO
            { C122.MAGIC, new ItemTypeStruct( C122.DISPLAY_NAME, typeof(C122) ) }, //FAFO
            { C124.MAGIC, new ItemTypeStruct( C124.DISPLAY_NAME, typeof(C124) ) },
            { C125.MAGIC, new ItemTypeStruct( C125.DISPLAY_NAME, typeof(C125) ) },
            { C126.MAGIC, new ItemTypeStruct( C126.DISPLAY_NAME, typeof(C126) ) }, //FAFO
            { C127.MAGIC, new ItemTypeStruct( C127.DISPLAY_NAME, typeof(C127) ) }, //FAFO
            { C128.MAGIC, new ItemTypeStruct( C128.DISPLAY_NAME, typeof(C128) ) }, //FAFO
            { C129.MAGIC, new ItemTypeStruct( C129.DISPLAY_NAME, typeof(C129) ) }, //FAFO
            { C130.MAGIC, new ItemTypeStruct( C130.DISPLAY_NAME, typeof(C130) ) },
            { C131.MAGIC, new ItemTypeStruct( C131.DISPLAY_NAME, typeof(C131) ) },
            { C132.MAGIC, new ItemTypeStruct( C132.DISPLAY_NAME, typeof(C132) ) }, //FAFO
            { C133.MAGIC, new ItemTypeStruct( C133.DISPLAY_NAME, typeof(C133) ) },
            { C135.MAGIC, new ItemTypeStruct( C135.DISPLAY_NAME, typeof(C135) ) }, //FAFO
            { C136.MAGIC, new ItemTypeStruct( C136.DISPLAY_NAME, typeof(C136) ) },
            { C137.MAGIC, new ItemTypeStruct( C137.DISPLAY_NAME, typeof(C137) ) },
            { C138.MAGIC, new ItemTypeStruct( C138.DISPLAY_NAME, typeof(C138) ) },
            { C139.MAGIC, new ItemTypeStruct( C139.DISPLAY_NAME, typeof(C139) ) },
            { C140.MAGIC, new ItemTypeStruct( C140.DISPLAY_NAME, typeof(C140) ) },
            { C141.MAGIC, new ItemTypeStruct( C141.DISPLAY_NAME, typeof(C141) ) },
            { C142.MAGIC, new ItemTypeStruct( C142.DISPLAY_NAME, typeof(C142) ) },
            { C143.MAGIC, new ItemTypeStruct( C143.DISPLAY_NAME, typeof(C143) ) },
            { C144.MAGIC, new ItemTypeStruct( C144.DISPLAY_NAME, typeof(C144) ) },
            { C145.MAGIC, new ItemTypeStruct( C145.DISPLAY_NAME, typeof(C145) ) }, //FAFO
            { C146.MAGIC, new ItemTypeStruct( C146.DISPLAY_NAME, typeof(C146) ) }, //FAFO
            { C147.MAGIC, new ItemTypeStruct( C147.DISPLAY_NAME, typeof(C147) ) }, //FAFO
            { C148.MAGIC, new ItemTypeStruct( C148.DISPLAY_NAME, typeof(C148) ) }, //FAFO
            { C149.MAGIC, new ItemTypeStruct( C149.DISPLAY_NAME, typeof(C149) ) }, //FAFO
            { C151.MAGIC, new ItemTypeStruct( C151.DISPLAY_NAME, typeof(C151) ) }, //FAFO
            { C152.MAGIC, new ItemTypeStruct( C152.DISPLAY_NAME, typeof(C152) ) }, //FAFO
            { C153.MAGIC, new ItemTypeStruct( C153.DISPLAY_NAME, typeof(C153) ) }, //FAFO
            { C154.MAGIC, new ItemTypeStruct( C154.DISPLAY_NAME, typeof(C154) ) }, //FAFO
            { C155.MAGIC, new ItemTypeStruct( C155.DISPLAY_NAME, typeof(C155) ) }, //FAFO
            { C156.MAGIC, new ItemTypeStruct( C156.DISPLAY_NAME, typeof(C156) ) },
            { C157.MAGIC, new ItemTypeStruct( C157.DISPLAY_NAME, typeof(C157) ) }, //FAFO
            { C158.MAGIC, new ItemTypeStruct( C158.DISPLAY_NAME, typeof(C158) ) },
            { C159.MAGIC, new ItemTypeStruct( C159.DISPLAY_NAME, typeof(C159) ) }, //FAFO
            { C160.MAGIC, new ItemTypeStruct( C160.DISPLAY_NAME, typeof(C160) ) }, //FAFO
            { C161.MAGIC, new ItemTypeStruct( C161.DISPLAY_NAME, typeof(C161) ) },
            { C162.MAGIC, new ItemTypeStruct( C162.DISPLAY_NAME, typeof(C162) ) },
            { C163.MAGIC, new ItemTypeStruct( C163.DISPLAY_NAME, typeof(C163) ) }, //FAFO
            { C164.MAGIC, new ItemTypeStruct( C164.DISPLAY_NAME, typeof(C164) ) }, //FAFO
            { C165.MAGIC, new ItemTypeStruct( C165.DISPLAY_NAME, typeof(C165) ) }, //FAFO
            { C166.MAGIC, new ItemTypeStruct( C166.DISPLAY_NAME, typeof(C166) ) }, //FAFO
            { C167.MAGIC, new ItemTypeStruct( C167.DISPLAY_NAME, typeof(C167) ) }, //FAFO
            { C168.MAGIC, new ItemTypeStruct( C168.DISPLAY_NAME, typeof(C168) ) },
            { C169.MAGIC, new ItemTypeStruct( C169.DISPLAY_NAME, typeof(C169) ) }, //FAFO
            { C170.MAGIC, new ItemTypeStruct( C170.DISPLAY_NAME, typeof(C170) ) }, //FAFO
            { C171.MAGIC, new ItemTypeStruct( C171.DISPLAY_NAME, typeof(C171) ) }, //FAFO
            { C172.MAGIC, new ItemTypeStruct( C172.DISPLAY_NAME, typeof(C172) ) }, //FAFO
            { C173.MAGIC, new ItemTypeStruct( C173.DISPLAY_NAME, typeof(C173) ) },
            { C174.MAGIC, new ItemTypeStruct( C174.DISPLAY_NAME, typeof(C174) ) },
            { C175.MAGIC, new ItemTypeStruct( C175.DISPLAY_NAME, typeof(C175) ) },
            { C176.MAGIC, new ItemTypeStruct( C176.DISPLAY_NAME, typeof(C176) ) },
            { C177.MAGIC, new ItemTypeStruct( C177.DISPLAY_NAME, typeof(C177) ) },
            { C178.MAGIC, new ItemTypeStruct( C178.DISPLAY_NAME, typeof(C178) ) },
            { C179.MAGIC, new ItemTypeStruct( C179.DISPLAY_NAME, typeof(C179) ) }, //FAFO
            { C180.MAGIC, new ItemTypeStruct( C180.DISPLAY_NAME, typeof(C180) ) }, //FAFO
            { C181.MAGIC, new ItemTypeStruct( C181.DISPLAY_NAME, typeof(C181) ) }, //FAFO
            { C182.MAGIC, new ItemTypeStruct( C182.DISPLAY_NAME, typeof(C182) ) }, //FAFO
            { C183.MAGIC, new ItemTypeStruct( C183.DISPLAY_NAME, typeof(C183) ) }, //FAFO
            { C184.MAGIC, new ItemTypeStruct( C184.DISPLAY_NAME, typeof(C184) ) }, //FAFO
            { C185.MAGIC, new ItemTypeStruct( C185.DISPLAY_NAME, typeof(C185) ) }, //FAFO
            { C186.MAGIC, new ItemTypeStruct( C186.DISPLAY_NAME, typeof(C186) ) }, //FAFO
            { C187.MAGIC, new ItemTypeStruct( C187.DISPLAY_NAME, typeof(C187) ) },
            { C188.MAGIC, new ItemTypeStruct( C188.DISPLAY_NAME, typeof(C188) ) },
            { C189.MAGIC, new ItemTypeStruct( C189.DISPLAY_NAME, typeof(C189) ) }, //FAFO
            { C190.MAGIC, new ItemTypeStruct( C190.DISPLAY_NAME, typeof(C190) ) }, //FAFO
            { C191.MAGIC, new ItemTypeStruct( C191.DISPLAY_NAME, typeof(C191) ) }, //FAFO
            { C192.MAGIC, new ItemTypeStruct( C192.DISPLAY_NAME, typeof(C192) ) },
            { C193.MAGIC, new ItemTypeStruct( C193.DISPLAY_NAME, typeof(C193) ) }, //FAFO
            { C194.MAGIC, new ItemTypeStruct( C194.DISPLAY_NAME, typeof(C194) ) },
            { C195.MAGIC, new ItemTypeStruct( C195.DISPLAY_NAME, typeof(C195) ) }, //FAFO
            { C196.MAGIC, new ItemTypeStruct( C196.DISPLAY_NAME, typeof(C196) ) }, //FAFO
            { C197.MAGIC, new ItemTypeStruct( C197.DISPLAY_NAME, typeof(C197) ) },
            { C198.MAGIC, new ItemTypeStruct( C198.DISPLAY_NAME, typeof(C198) ) },
            { C199.MAGIC, new ItemTypeStruct( C199.DISPLAY_NAME, typeof(C199) ) }, //FAFO
            { C200.MAGIC, new ItemTypeStruct( C200.DISPLAY_NAME, typeof(C200) ) }, //FAFO
            { C201.MAGIC, new ItemTypeStruct( C201.DISPLAY_NAME, typeof(C201) ) }, //FAFO
            { C202.MAGIC, new ItemTypeStruct( C202.DISPLAY_NAME, typeof(C202) ) },
            { C203.MAGIC, new ItemTypeStruct( C203.DISPLAY_NAME, typeof(C203) ) },
            { C204.MAGIC, new ItemTypeStruct( C204.DISPLAY_NAME, typeof(C204) ) },
            { C206.MAGIC, new ItemTypeStruct( C206.DISPLAY_NAME, typeof(C206) ) }, //FAFO
            { C207.MAGIC, new ItemTypeStruct( C207.DISPLAY_NAME, typeof(C207) ) }, //FAFO
            { C208.MAGIC, new ItemTypeStruct( C208.DISPLAY_NAME, typeof(C208) ) },
            { C209.MAGIC, new ItemTypeStruct( C209.DISPLAY_NAME, typeof(C209) ) },
            { C210.MAGIC, new ItemTypeStruct( C210.DISPLAY_NAME, typeof(C210) ) }, //FAFO
            { C211.MAGIC, new ItemTypeStruct( C211.DISPLAY_NAME, typeof(C211) ) },
            { C212.MAGIC, new ItemTypeStruct( C212.DISPLAY_NAME, typeof(C212) ) },
            { C213.MAGIC, new ItemTypeStruct( C213.DISPLAY_NAME, typeof(C213) ) }, //FAFO
            { C214.MAGIC, new ItemTypeStruct( C214.DISPLAY_NAME, typeof(C214) ) }, //FAFO
            { C215.MAGIC, new ItemTypeStruct( C215.DISPLAY_NAME, typeof(C215) ) },
            { C216.MAGIC, new ItemTypeStruct( C216.DISPLAY_NAME, typeof(C216) ) },
            { C217.MAGIC, new ItemTypeStruct( C217.DISPLAY_NAME, typeof(C217) ) },
            { C218.MAGIC, new ItemTypeStruct( C218.DISPLAY_NAME, typeof(C218) ) },
            { C219.MAGIC, new ItemTypeStruct( C219.DISPLAY_NAME, typeof(C219) ) },
            { C220.MAGIC, new ItemTypeStruct( C220.DISPLAY_NAME, typeof(C220) ) },
            { C221.MAGIC, new ItemTypeStruct( C221.DISPLAY_NAME, typeof(C221) ) },
            { C222.MAGIC, new ItemTypeStruct( C222.DISPLAY_NAME, typeof(C222) ) }, //FAFO
            { C223.MAGIC, new ItemTypeStruct( C223.DISPLAY_NAME, typeof(C223) ) }, //FAFO
            { C224.MAGIC, new ItemTypeStruct( C224.DISPLAY_NAME, typeof(C224) ) }, //FAFO
            { C225.MAGIC, new ItemTypeStruct( C225.DISPLAY_NAME, typeof(C225) ) }, //FAFO
            { C226.MAGIC, new ItemTypeStruct( C226.DISPLAY_NAME, typeof(C226) ) }, //FAFO
            { C227.MAGIC, new ItemTypeStruct( C227.DISPLAY_NAME, typeof(C227) ) },
            { C228.MAGIC, new ItemTypeStruct( C228.DISPLAY_NAME, typeof(C228) ) },
            { C229.MAGIC, new ItemTypeStruct( C229.DISPLAY_NAME, typeof(C229) ) }, //
            { C230.MAGIC, new ItemTypeStruct( C230.DISPLAY_NAME, typeof(C230) ) },
            { C231.MAGIC, new ItemTypeStruct( C231.DISPLAY_NAME, typeof(C231) ) }, //
            { C232.MAGIC, new ItemTypeStruct( C232.DISPLAY_NAME, typeof(C232) ) }, //
            { C233.MAGIC, new ItemTypeStruct( C233.DISPLAY_NAME, typeof(C233) ) }, //
            { C234.MAGIC, new ItemTypeStruct( C234.DISPLAY_NAME, typeof(C234) ) }, //
            { C235.MAGIC, new ItemTypeStruct( C235.DISPLAY_NAME, typeof(C235) ) }, //FAFO
        };
    }
}
