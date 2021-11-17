﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ambar.Model.DAO;
using Ambar.Model.DTO;
using Cassandra;
using Ambar.Common;
using Ambar.Properties;
using Ambar.ViewController.Objects;
using Ambar.Model.AmbarMapper;

namespace Ambar.ViewController
{
    public partial class Contracts : Form
    {
        ContractDAO contractDAO = new ContractDAO();
        DateDAO dateDAO = new DateDAO();
        int dtgPrevIndex = -1;

        public Contracts()
        {
            InitializeComponent();
        }

        private void Contratos_Load(object sender, EventArgs e)
        {
            FillClientDataGridView();
            cbService.SelectedIndex = 0;
            cbState.SelectedIndex = 0;
            dtpStartPeriodDate.Value = dtpStartPeriodDate.MinDate;
            dtpStartPeriodDate.MinDate = dateDAO.GetDate();
        }

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] cities = null;

            switch (cbState.SelectedIndex)
            {
                case -1:
                {
                    return;
                }
                case 0:
                {
                    cities = new string[] {"Seleccionar" };
                    break;
                }
                case 1: // Aguascalientes
                {
                    cities = new string[] {"Seleccionar", "AGUASCALIENTES", "ASIENTOS", "CALVILLO", "COSÍO", "EL LLANO",
                    "JESÚS MARÍA", "PABELLÓN DE ARTEAGA", "RINCÓN DE ROMOS", "SAN FRANCISCO DE LOS ROMO",
                        "SAN JOSÉ DE GRACIA", "TEPEZALÁ" };
                    break;
                }
                case 2: // Baja California 
                {
                    cities = new string[] { "Seleccionar", "ENSENADA", "MEXICALI", "TECATE", "TIJUANA", "PLAYAS DE ROSARITO" };
                    break;
                }
                case 3: // Baja California Sur
                {
                    cities = new string[] {"Seleccionar", "COMONDÚ", "MULEGÉ", "LA PAZ", "LOS CABOS", "LORETO" };
                    break;
                }
                case 4: // Campeche
                {
                    cities = new string[] {"Seleccionar", "CALKINÍ", "CAMPECHE", "CARMEN", "CHAMPOTÓN", "HECELCHAKÁN", "HOPELCHÉN",
                        "PALIZADA", "TENABO", "ESCÁRCEGA", "CALAKMUL", "CANDELARIA"};
                    break;
                }
                case 5: // Chiapas
                {
                    cities = new string[] { "Seleccionar", "ACACOYAGUA","ACALA","ACAPETAHUA","ALTAMIRANO","AMATÁN",
                    "AMATENANGO DE LA FRONTERA","AMATENANGO DEL VALLE","ANGEL ALBINO CORZO","ARRIAGA","BEJUCAL DE OCAMPO",
                        "BELLA VISTA","BERRIOZÁBAL","BOCHIL","EL BOSQUE","CACAHOATÁN","CATAZAJÁ","CINTALAPA",
                        "COAPILLA","COMITÁN DE DOMÍNGUEZ","LA CONCORDIA","COPAINALÁ","CHALCHIHUITÁN","CHAMULA","CHANAL",
                        "CHAPULTENANGO","CHENALHÓ","CHIAPA DE CORZO","CHIAPILLA","CHICOASÉN","CHICOMUSELO","CHILÓN",
                        "ESCUINTLA","FRANCISCO LEÓN","FRONTERA COMALAPA","FRONTERA HIDALGO","LA GRANDEZA","HUEHUETÁN",
                        "HUIXTÁN","HUITIUPÁN","HUIXTLA","LA INDEPENDENCIA","IXHUATÁN","IXTACOMITÁN","IXTAPA",
                        "IXTAPANGAJOYA","JIQUIPILAS","JITOTOL","JUÁREZ","LARRÁINZAR","LA LIBERTAD","MAPASTEPEC",
                        "LAS MARGARITAS","MAZAPA DE MADERO","MAZATÁN","METAPA","MITONTIC","MOTOZINTLA","NICOLÁS RUÍZ",
                        "OCOSINGO","OCOTEPEC","OCOZOCOAUTLA DE ESPINOSA","OSTUACÁN","OSUMACINTA","OXCHUC","PALENQUE",
                        "PANTELHÓ","PANTEPEC","PICHUCALCO","PIJIJIAPAN","EL PORVENIR",
                        "PUEBLO NUEVO SOLISTAHUACÁN","RAYÓN","REFORMA","LAS ROSAS","SABANILLA","SALTO DE AGUA",
                        "SAN CRISTÓBAL DE LAS CASAS","SAN FERNANDO","SILTEPEC","SIMOJOVEL","SITALÁ","SOCOLTENANGO",
                        "SOLOSUCHIAPA","SOYALÓ","SUCHIAPA","SUCHIATE","SUNUAPA","TAPACHULA","TAPALAPA","TAPILULA",
                        "TECPATÁN","TENEJAPA","TEOPISCA","TILA","TONALÁ","TOTOLAPA","LA TRINITARIA","TUMBALÁ",
                        "TUXTLA GUTIÉRREZ","TUXTLA CHICO","TUZANTÁN","TZIMOL","UNIÓN JUÁREZ","VENUSTIANO CARRANZA",
                        "VILLA COMALTITLÁN","VILLA CORZO","VILLAFLORES","YAJALÓN","SAN LUCAS","ZINACANTÁN",
                        "SAN JUAN CANCUC","ALDAMA","BENEMÉRITO DE LAS AMÉRICAS","MARAVILLA TENEJAPA","MARQUÉS DE COMILLAS",
                        "MONTECRISTO DE GUERRERO","SAN ANDRÉS DURAZNAL","SANTIAGO EL PINAR"};
                    break;
                }
                case 6: // Chihuahua
                {
                    cities = new string[] { "Seleccionar", "AHUMADA", "ALDAMA", "ALLENDE", "AQUILES SERDÁN", "ASCENSIÓN", "BACHÍNIVA", 
                        "BALLEZA", "BATOPILAS", "BOCOYNA", "BUENAVENTURA", "CAMARGO", "CARICHÍ", "CASAS GRANDES", 
                        "CORONADO", "COYAME DEL SOTOL", "LA CRUZ", "CUAUHTÉMOC", "CUSIHUIRIACHI", "CHIHUAHUA", "CHÍNIPAS", 
                        "DELICIAS", "DR. BELISARIO DOMÍNGUEZ", "GALEANA", "SANTA ISABEL", "GÓMEZ FARÍAS", "GRAN MORELOS", 
                        "GUACHOCHI", "GUADALUPE", "GUADALUPE Y CALVO", "GUAZAPARES", "GUERRERO", "HIDALGO DEL PARRAL", 
                        "HUEJOTITÁN", "IGNACIO ZARAGOZA", "JANOS", "JIMÉNEZ", "JUÁREZ", "JULIMES", "LÓPEZ", "MADERA", 
                        "MAGUARICHI", "MANUEL BENAVIDES", "MATACHÍ", "MATAMOROS", "MEOQUI", "MORELOS", "MORIS", "NAMIQUIPA",
                        "NONOAVA", "NUEVO CASAS GRANDES", "OCAMPO", "OJINAGA", "PRAXEDIS G. GUERRERO", "RIVA PALACIO", 
                        "ROSALES", "ROSARIO", "SAN FRANCISCO DE BORJA", "SAN FRANCISCO DE CONCHOS", "SAN FRANCISCO DEL ORO",
                        "SANTA BÁRBARA", "SATEVÓ", "SAUCILLO", "TEMÓSACHIC", "EL TULE", "URIQUE", "URUACHI", "VALLE DE ZARAGOZA"};
                    break;
                }
                case 7: // Ciudad de Mexico
                {
                    cities = new string[] { "Seleccionar", "AZCAPOTZALCO", "COYOACÁN", "CUAJIMALPA DE MORELOS", "GUSTAVO A. MADERO",
                        "IZTACALCO", "IZTAPALAPA", "LA MAGDALENA CONTRERAS", "MILPA ALTA", "ÁLVARO OBREGÓN", "TLÁHUAC",
                        "TLALPAN", "XOCHIMILCO", "BENITO JUÁREZ", "CUAUHTÉMOC", "MIGUEL HIDALGO", "VENUSTIANO CARRANZA" };
                    break;
                }
                case 8: // Coahuila
                {
                    cities = new string[] {"Seleccionar",  "ABASOLO", "ACUÑA", "ALLENDE", "ARTEAGA", "CANDELA", "CASTAÑOS",
                        "CUATRO CIÉNEGAS", "ESCOBEDO", "FRANCISCO I. MADERO", "FRONTERA", "GENERAL CEPEDA", "GUERRERO",
                        "HIDALGO", "JIMÉNEZ", "JUÁREZ", "LAMADRID", "MATAMOROS", "MONCLOVA", "MORELOS", "MÚZQUIZ",
                        "NADADORES", "NAVA", "OCAMPO", "PARRAS", "PIEDRAS NEGRAS", "PROGRESO", "RAMOS ARIZPE", "SABINAS",
                        "SACRAMENTO", "SALTILLO", "SAN BUENAVENTURA", "SAN JUAN DE SABINAS", "SAN PEDRO", "SIERRA MOJADA",
                        "TORREÓN", "VIESCA", "VILLA UNIÓN", "ZARAGOZA" };
                    break;
                }
                case 9: // Colima
                {
                    cities = new string[] {"Seleccionar",  "ARMERÍA", "COLIMA", "COMALA", "COQUIMATLÁN", "CUAUHTÉMOC", "IXTLAHUACÁN",
                       "MANZANILLO", "MINATITLÁN", "TECOMÁN", "VILLA DE ÁLVAREZ" };
                    break;
                }
                case 10: // Durango
                {
                    cities = new string[] {"Seleccionar",  "CANATLÁN", "CANELAS", "CONETO DE COMONFORT", "CUENCAMÉ", "DURANGO", 
                        "GENERAL SIMÓN BOLÍVAR", "GÓMEZ PALACIO", "GUADALUPE VICTORIA", "GUANACEVÍ", "HIDALGO", "INDÉ", "LERDO", 
                        "MAPIMÍ", "MEZQUITAL", "NAZAS", "NOMBRE DE DIOS", "NUEVO IDEAL", "OCAMPO", "EL ORO", "OTÁEZ", 
                        "PÁNUCO DE CORONADO", "PEÑÓN BLANCO", "POANAS", "PUEBLO NUEVO", "RODEO", "SAN BERNARDO", "SAN DIMAS", 
                        "SAN JUAN DE GUADALUPE", "SAN JUAN DEL RÍO", "SAN LUIS DEL CORDERO", "SAN PEDRO DEL GALLO", "SANTA CLARA",
                        "SANTIAGO PAPASQUIARO", "SÚCHIL", "TAMAZULA", "TEPEHUANES", "TLAHUALILO", "TOPIA",
                        "VICENTE GUERRERO" };
                    break;
                }
                case 11: // Guanajuato
                {
                    cities = new string[] {"Seleccionar",  "ABASOLO", "ACÁMBARO", "SAN MIGUEL DE ALLENDE", "APASEO EL ALTO",
                        "APASEO EL GRANDE", "ATARJEA", "CELAYA", "COMONFORT", "CORONEO", "CORTAZAR", "CUERÁMARO",
                        "DOCTOR MORA", "DOLORES HIDALGO CUNA DE LA INDEPENDENCIA NACIONAL", "GUANAJUATO", "HUANÍMARO",
                        "IRAPUATO", "JARAL DEL PROGRESO", "JERÉCUARO", "LEÓN", "MANUEL DOBLADO", "MOROLEÓN", "OCAMPO",
                        "PÉNJAMO", "PUEBLO NUEVO", "PURÍSIMA DEL RINCÓN", "ROMITA", "SALAMANCA", "SALVATIERRA",
                        "SAN DIEGO DE LA UNIÓN", "SAN FELIPE", "SAN FRANCISCO DEL RINCÓN", "SAN JOSÉ ITURBIDE",
                        "SAN LUIS DE LA PAZ", "SANTA CATARINA", "SANTA CRUZ DE JUVENTINO ROSAS", "SANTIAGO MARAVATÍO",
                        "SILAO DE LA VICTORIA", "TARANDACUAO", "TARIMORO", "TIERRA BLANCA", "URIANGATO",
                        "VALLE DE SANTIAGO", "VICTORIA", "VILLAGRÁN", "XICHÚ", "YURIRIA" };
                    break;
                }
                case 12: // Guerrero
                {
                    cities = new string[] {"Seleccionar",  "ACAPULCO DE JUÁREZ", "ACATEPEC", "AHUACUOTZINGO", "AJUCHITLÁN DEL PROGRESO", 
                        "ALCOZAUCA DE GUERRERO", "ALPOYECA", "APAXTLA", "ARCELIA", "ATENANGO DEL RÍO", "ATLAMAJALCINGO DEL MONTE", 
                        "ATLIXTAC", "ATOYAC DE ÁLVAREZ", "AYUTLA DE LOS LIBRES", "AZOYÚ", "BENITO JUÁREZ", "BUENAVISTA DE CUÉLLAR", 
                        "COAHUAYUTLA DE JOSÉ MARÍA IZAZAGA", "COCHOAPA EL GRANDE", "COCULA", "COPALA", "COPALILLO", "COPANATOYAC", 
                        "COYUCA DE BENÍTEZ", "COYUCA DE CATALÁN", "CUAJINICUILAPA", "CUALÁC", "CUAUTEPEC", "CUETZALA DEL PROGRESO", 
                        "CUTZAMALA DE PINZÓN", "CHILAPA DE ÁLVAREZ", "CHILPANCINGO DE LOS BRAVO", "EDUARDO NERI", "FLORENCIO VILLARREAL", 
                        "GENERAL CANUTO A. NERI", "GENERAL HELIODORO CASTILLO", "HUAMUXTITLÁN", "HUITZUCO DE LOS FIGUEROA", 
                        "IGUALA DE LA INDEPENDENCIA", "IGUALAPA", "ILIATENCO", "IXCATEOPAN DE CUAUHTÉMOC", "JOSÉ JOAQUÍN DE HERRERA", 
                        "JUCHITÁN", "JUAN R. ESCUDERO", "LEONARDO BRAVO", "MALINALTEPEC", "MARQUELIA", "MÁRTIR DE CUILAPAN", 
                        "METLATÓNOC", "MOCHITLÁN", "OLINALÁ", "OMETEPEC", "PEDRO ASCENCIO ALQUISIRAS", "PETATLÁN", "PILCAYA", 
                        "PUNGARABATO", "QUECHULTENANGO", "SAN LUIS ACATLÁN", "SAN MARCOS", "SAN MIGUEL TOTOLAPAN", "TAXCO DE ALARCÓN", 
                        "TECOANAPA", "TÉCPAN DE GALEANA", "TELOLOAPAN", "TEPECOACUILCO DE TRUJANO", "TETIPAC", "TIXTLA DE GUERRERO", 
                        "TLACOACHISTLAHUACA", "TLACOAPA", "TLALCHAPA", "TLALIXTAQUILLA DE MALDONADO", "TLAPA DE COMONFORT", "TLAPEHUALA", 
                        "LA UNIÓN DE ISIDORO MONTES DE OCA", "XALPATLÁHUAC", "XOCHIHUEHUETLÁN", "XOCHISTLAHUACA", "ZAPOTITLÁN TABLAS", 
                        "ZIHUATANEJO DE AZUETA", "ZIRÁNDARO", "ZITLALA" };
                    break;
                }
                case 13: // Hidalgo
                {
                    cities = new string[] {"Seleccionar",  "ACATLÁN", "ACAXOCHITLÁN", "ACTOPAN", "AGUA BLANCA DE ITURBIDE", "AJACUBA", "ALFAJAYUCAN", 
                        "ALMOLOYA", "APAN", "EL ARENAL", "ATITALAQUIA", "ATLAPEXCO", "ATOTONILCO EL GRANDE", "ATOTONILCO DE TULA", 
                        "CALNALI", "CARDONAL", "CUAUTEPEC DE HINOJOSA", "CHAPANTONGO", "CHAPULHUACÁN", "CHILCUAUTLA", "ELOXOCHITLÁN", 
                        "EMILIANO ZAPATA", "EPAZOYUCAN", "FRANCISCO I. MADERO", "HUASCA DE OCAMPO", "HUAUTLA", "HUAZALINGO", 
                        "HUEHUETLA", "HUEJUTLA DE REYES", "HUICHAPAN", "IXMIQUILPAN", "JACALA DE LEDEZMA", "JALTOCÁN", "JUÁREZ HIDALGO", 
                        "LOLOTLA", "METEPEC", "SAN AGUSTÍN METZQUITITLÁN", "METZTITLÁN", "MINERAL DEL CHICO", "MINERAL DEL MONTE", 
                        "LA MISIÓN", "MIXQUIAHUALA DE JUÁREZ", "MOLANGO DE ESCAMILLA", "NICOLÁS FLORES", "NOPALA DE VILLAGRÁN",
                        "OMITLÁN DE JUÁREZ", "SAN FELIPE ORIZATLÁN", "PACULA", "PACHUCA DE SOTO", "PISAFLORES", "PROGRESO DE OBREGÓN", 
                        "MINERAL DE LA REFORMA", "SAN AGUSTÍN TLAXIACA", "SAN BARTOLO TUTOTEPEC", "SAN SALVADOR", "SANTIAGO DE ANAYA", 
                        "SANTIAGO TULANTEPEC DE LUGO GUERRERO", "SINGUILUCAN", "TASQUILLO", "TECOZAUTLA", "TENANGO DE DORIA", 
                        "TEPEAPULCO", "TEPEHUACÁN DE GUERRERO", "TEPEJI DEL RÍO DE OCAMPO", "TEPETITLÁN", "TETEPANGO", 
                        "VILLA DE TEZONTEPEC", "TEZONTEPEC DE ALDAMA", "TIANGUISTENGO", "TIZAYUCA", "TLAHUELILPAN", "TLAHUILTEPA", 
                        "TLANALAPA", "TLANCHINOL", "TLAXCOAPAN", "TOLCAYUCA", "TULA DE ALLENDE", "TULANCINGO DE BRAVO", "XOCHIATIPAN", 
                        "XOCHICOATLÁN", "YAHUALICA", "ZACUALTIPÁN DE ÁNGELES", "ZAPOTLÁN DE JUÁREZ", "ZEMPOALA", "ZIMAPÁN"};
                    break;
                }
                case 14: // Jalisco
                {
                    cities = new string[] {"Seleccionar",  "ACATIC", "ACATLÁN DE JUÁREZ", "AHUALULCO DE MERCADO", "AMACUECA", "AMATITÁN", 
                        "AMECA", "ARANDAS", "EL ARENAL", "ATEMAJAC DE BRIZUELA", "ATENGO", "ATENGUILLO", 
                        "ATOTONILCO EL ALTO", "ATOYAC", "AUTLÁN DE NAVARRO", "AYOTLÁN", "AYUTLA", "LA BARCA", "BOLAÑOS", 
                        "CABO CORRIENTES", "CAÑADAS DE OBREGÓN", "CASIMIRO CASTILLO", "CIHUATLÁN", "COCULA", "COLOTLÁN", 
                        "CONCEPCIÓN DE BUENOS AIRES", "CUAUTITLÁN DE GARCÍA BARRAGÁN", "CUAUTLA", "CUQUÍO", "CHAPALA", 
                        "CHIMALTITÁN", "CHIQUILISTLÁN", "DEGOLLADO", "EJUTLA", "ENCARNACIÓN DE DÍAZ", "ETZATLÁN", 
                        "EL GRULLO", "GUACHINANGO", "GUADALAJARA", "HOSTOTIPAQUILLO", "HUEJÚCAR", "HUEJUQUILLA EL ALTO", 
                        "LA HUERTA", "IXTLAHUACÁN DE LOS MEMBRILLOS", "IXTLAHUACÁN DEL RÍO", "JALOSTOTITLÁN", "JAMAY", 
                        "JESÚS MARÍA", "JILOTLÁN DE LOS DOLORES", "JOCOTEPEC", "JUANACATLÁN", "JUCHITLÁN", 
                        "LAGOS DE MORENO", "EL LIMÓN", "MAGDALENA", "SANTA MARÍA DEL ORO", "LA MANZANILLA DE LA PAZ", 
                        "MASCOTA", "MAZAMITLA", "MEXTICACÁN", "MEZQUITIC", "MIXTLÁN", "OCOTLÁN", "OJUELOS DE JALISCO", 
                        "PIHUAMO", "PONCITLÁN", "PUERTO VALLARTA", "VILLA PURIFICACIÓN", "QUITUPAN", "EL SALTO", 
                        "SAN CRISTÓBAL DE LA BARRANCA", "SAN DIEGO DE ALEJANDRÍA", "SAN JUAN DE LOS LAGOS", 
                        "SAN JUANITO DE ESCOBEDO", "SAN JULIÁN", "SAN MARCOS", "SAN MARTÍN DE BOLAÑOS", 
                        "SAN MARTÍN HIDALGO", "SAN MIGUEL EL ALTO", "GÓMEZ FARÍAS", "SAN SEBASTIÁN DEL OESTE", 
                        "SANTA MARÍA DE LOS ÁNGELES", "SAYULA", "TALA", "TALPA DE ALLENDE", "TAMAZULA DE GORDIANO", 
                        "TAPALPA", "TECALITLÁN", "TECOLOTLÁN", "TECHALUTA DE MONTENEGRO", "TENAMAXTLÁN", "TEOCALTICHE", 
                        "TEOCUITATLÁN DE CORONA", "TEPATITLÁN DE MORELOS", "TEQUILA", "TEUCHITLÁN", "TIZAPÁN EL ALTO", 
                        "TLAJOMULCO DE ZÚÑIGA", "SAN GABRIEL", "SAN IGNACIO CERRO GORDO", "SAN PEDRO TLAQUEPAQUE", 
                        "TOLIMÁN", "TOMATLÁN", "TONALÁ", "TONAYA", "TONILA", "TOTATICHE", "TOTOTLÁN", "TUXCACUESCO", 
                        "TUXCUECA", "TUXPAN", "UNIÓN DE SAN ANTONIO", "UNIÓN DE TULA", "VALLE DE GUADALUPE", 
                        "VALLE DE JUÁREZ", "VILLA CORONA", "VILLA GUERRERO", "VILLA HIDALGO", "YAHUALICA DE GONZÁLEZ GALLO", 
                        "ZACOALCO DE TORRES", "ZAPOPAN", "ZAPOTILTIC", "ZAPOTITLÁN DE VADILLO", "ZAPOTLÁN DEL REY", 
                        "ZAPOTLÁN EL GRANDE", "ZAPOTLANEJO"};
                    break;
                }
                case 15: // Mexico
                {
                    cities = new string[] {"Seleccionar",  "ACAMBAY DE RUÍZ CASTAÑEDA", "ACOLMAN", "ACULCO", "ALMOLOYA DE ALQUISIRAS", 
                        "ALMOLOYA DE JUÁREZ", "ALMOLOYA DEL RÍO", "AMANALCO", "AMATEPEC", "AMECAMECA", "APAXCO", "ATENCO", 
                        "ATIZAPÁN", "ATIZAPÁN DE ZARAGOZA", "ATLACOMULCO", "ATLAUTLA", "AXAPUSCO", "AYAPANGO", "CALIMAYA", 
                        "CAPULHUAC", "COACALCO DE BERRIOZÁBAL", "COATEPEC HARINAS", "COCOTITLÁN", "COYOTEPEC", "CUAUTITLÁN", 
                        "CHALCO", "CHAPA DE MOTA", "CHAPULTEPEC", "CHIAUTLA", "CHICOLOAPAN", "CHICONCUAC", "CHIMALHUACÁN", 
                        "CUAUTITLÁN IZCALLI", "DONATO GUERRA", "ECATEPEC DE MORELOS", "ECATZINGO", "HUEHUETOCA", 
                        "HUEYPOXTLA", "HUIXQUILUCAN", "ISIDRO FABELA", "IXTAPALUCA", "IXTAPAN DE LA SAL", "IXTAPAN DEL ORO", 
                        "IXTLAHUACA", "XALATLACO", "JALTENCO", "JILOTEPEC", "JILOTZINGO", "JIQUIPILCO", "JOCOTITLÁN", 
                        "JOQUICINGO", "JUCHITEPEC", "LERMA", "LUVIANOS", "MALINALCO", "MELCHOR OCAMPO", "METEPEC", 
                        "MEXICALTZINGO", "MORELOS", "NAUCALPAN DE JUÁREZ", "NEZAHUALCÓYOTL", "NEXTLALPAN", "NICOLÁS ROMERO",
                        "NOPALTEPEC", "OCOYOACAC", "OCUILAN", "EL ORO", "OTUMBA", "OTZOLOAPAN", "OTZOLOTEPEC", "OZUMBA", 
                        "PAPALOTLA", "LA PAZ", "POLOTITLÁN", "RAYÓN", "SAN ANTONIO LA ISLA", "SAN FELIPE DEL PROGRESO", 
                        "SAN JOSÉ DEL RINCÓN", "SAN MARTÍN DE LAS PIRÁMIDES", "SAN MATEO ATENCO", "SAN SIMÓN DE GUERRERO", 
                        "SANTO TOMÁS", "SOYANIQUILPAN DE JUÁREZ", "SULTEPEC", "TECÁMAC", "TEJUPILCO", "TEMAMATLA", 
                        "TEMASCALAPA", "TEMASCALCINGO", "TEMASCALTEPEC", "TEMOAYA", "TENANCINGO", "TENANGO DEL AIRE", 
                        "TENANGO DEL VALLE", "TEOLOYUCAN", "TEOTIHUACÁN", "TEPETLAOXTOC", "TEPETLIXPA", "TEPOTZOTLÁN", 
                        "TEQUIXQUIAC", "TEXCALTITLÁN", "TEXCALYACAC", "TEXCOCO", "TEZOYUCA", "TIANGUISTENCO", "TIMILPAN", 
                        "TLALMANALCO", "TLALNEPANTLA DE BAZ", "TLATLAYA", "TOLUCA", "TONANITLA", "TONATICO", "TULTEPEC", 
                        "TULTITLÁN", "VALLE DE BRAVO", "VALLE DE CHALCO SOLIDARIDAD", "VILLA DE ALLENDE", "VILLA DEL CARBÓN", 
                        "VILLA GUERRERO", "VILLA VICTORIA", "XONACATLÁN", "ZACAZONAPAN", "ZACUALPAN", "ZINACANTEPEC", 
                        "ZUMPAHUACÁN", "ZUMPANGO" };
                    break;
                }
                case 16: // Michoacan
                {
                    cities = new string[] {"Seleccionar",  "ACUITZIO", "AGUILILLA", "ÁLVARO OBREGÓN", "ANGAMACUTIRO", "ANGANGUEO", 
                        "APATZINGÁN", "APORO", "AQUILA", "ARIO", "ARTEAGA", "BRISEÑAS", "BUENAVISTA", "CARÁCUARO", 
                        "COAHUAYANA", "COALCOMÁN DE VÁZQUEZ PALLARES", "COENEO", "COJUMATLÁN DE RÉGULES", "CONTEPEC", 
                        "COPÁNDARO", "COTIJA", "CUITZEO", "CHARAPAN", "CHARO", "CHAVINDA", "CHERÁN", "CHILCHOTA", 
                        "CHINICUILA", "CHUCÁNDIRO", "CHURINTZIO", "CHURUMUCO", "ECUANDUREO", "EPITACIO HUERTA", 
                        "ERONGARÍCUARO", "GABRIEL ZAMORA", "HIDALGO", "LA HUACANA", "HUANDACAREO", "HUANIQUEO", "HUETAMO", 
                        "HUIRAMBA", "INDAPARAPEO", "IRIMBO", "IXTLÁN", "JACONA", "JIMÉNEZ", "JIQUILPAN", 
                        "JOSÉ SIXTO VERDUZCO", "JUÁREZ", "JUNGAPEO", "LAGUNILLAS", "MADERO", "MARAVATÍO", 
                        "MARCOS CASTELLANOS", "LÁZARO CÁRDENAS", "MORELIA", "MORELOS", "MÚGICA", "NAHUATZEN", "NOCUPÉTARO", 
                        "NUEVO PARANGARICUTIRO", "NUEVO URECHO", "NUMARÁN", "OCAMPO", "PAJACUARÁN", "PANINDÍCUARO", 
                        "PARÁCUARO", "PARACHO", "PÁTZCUARO", "PENJAMILLO", "PERIBÁN", "LA PIEDAD", "PURÉPERO", "PURUÁNDIRO", 
                        "QUERÉNDARO", "QUIROGA", "LOS REYES", "SAHUAYO", "SAN LUCAS", "SANTA ANA MAYA", 
                        "SALVADOR ESCALANTE", "SENGUIO", "SUSUPUATO", "TACÁMBARO", "TANCÍTARO", "TANGAMANDAPIO", 
                        "TANGANCÍCUARO", "TANHUATO", "TARETAN", "TARÍMBARO", "TEPALCATEPEC", "TINGAMBATO", "TINGÜINDÍN", 
                        "TIQUICHEO DE NICOLÁS ROMERO", "TLALPUJAHUA", "TLAZAZALCA", "TOCUMBO", "TUMBISCATÍO", "TURICATO", 
                        "TUXPAN", "TUZANTLA", "TZINTZUNTZAN", "TZITZIO", "URUAPAN", "VENUSTIANO CARRANZA", "VILLAMAR", 
                        "VISTA HERMOSA", "YURÉCUARO", "ZACAPU", "ZAMORA", "ZINÁPARO", "ZINAPÉCUARO", "ZIRACUARETIRO", 
                        "ZITÁCUARO" };
                    break;
                }
                case 17: // Morelos
                {
                    cities = new string[] { "Seleccionar", "AMACUZAC", "ATLATLAHUCAN", "AXOCHIAPAN", "AYALA", "COATLÁN DEL RÍO", "CUAUTLA", 
                        "CUERNAVACA", "EMILIANO ZAPATA", "HUITZILAC", "JANTETELCO", "JIUTEPEC", "JOJUTLA", 
                        "JONACATEPEC DE LEANDRO VALLE", "MAZATEPEC", "MIACATLÁN", "OCUITUCO", "PUENTE DE IXTLA", "TEMIXCO", 
                        "TEPALCINGO", "TEPOZTLÁN", "TETECALA", "TETELA DEL VOLCÁN", "TLALNEPANTLA", "TLALTIZAPÁN DE ZAPATA", 
                        "TLAQUILTENANGO", "TLAYACAPAN", "TOTOLAPAN", "XOCHITEPEC", "YAUTEPEC", "YECAPIXTLA", "ZACATEPEC", 
                        "ZACUALPAN DE AMILPAS", "TEMOAC" };
                    break;
                }
                case 18: // Nayarit
                {
                    cities = new string[] { "Seleccionar", "ACAPONETA", "AHUACATLÁN", "AMATLÁN DE CAÑAS", "COMPOSTELA", "HUAJICORI",
                        "IXTLÁN DEL RÍO", "JALA", "XALISCO", "DEL NAYAR", "ROSAMORADA", "RUÍZ", "SAN BLAS",
                        "SAN PEDRO LAGUNILLAS", "SANTA MARÍA DEL ORO", "SANTIAGO IXCUINTLA", "TECUALA", "TEPIC", "TUXPAN",
                        "LA YESCA", "BAHÍA DE BANDERAS" };
                   break;
                }
                case 19: // Nuevo Leon
                {
                    cities = new string[] {"Seleccionar",  "ABASOLO", "AGUALEGUAS", "LOS ALDAMAS", "ALLENDE", "ANÁHUAC", "APODACA",
                    "ARAMBERRI", "BUSTAMANTE", "CADEREYTA JIMÉNEZ", "EL CARMEN", "CERRALVO", "CIÉNEGA DE FLORES", "CHINA",
                    "DOCTOR ARROYO", "DOCTOR COSS", "DOCTOR GONZÁLEZ", "GALEANA", "GARCÍA", "SAN PEDRO GARZA GARCÍA",
                    "GENERAL BRAVO", "GENERAL ESCOBEDO", "GENERAL TERÁN", "GENERAL TREVIÑO", "GENERAL ZARAGOZA",
                    "GENERAL ZUAZUA", "GUADALUPE", "LOS HERRERAS", "HIGUERAS", "HUALAHUISES", "ITURBIDE", "JUÁREZ",
                    "LAMPAZOS DE NARANJO", "LINARES", "MARÍN", "MELCHOR OCAMPO", "MIER Y NORIEGA", "MINA", "MONTEMORELOS", 
                        "MONTERREY", "PARÁS", "PESQUERÍA", "LOS RAMONES", "RAYONES", "SABINAS HIDALGO", "SALINAS VICTORIA", 
                        "SAN NICOLÁS DE LOS GARZA", "HIDALGO", "SANTA CATARINA", "SANTIAGO", "VALLECILLO", "VILLALDAMA" };
                    break;
                }
                case 20: // Oaxaca
                {
                    cities = new string[] {"Seleccionar",  "ABEJONES", "ACATLÁN DE PÉREZ FIGUEROA", "ASUNCIÓN CACALOTEPEC", 
                        "ASUNCIÓN CUYOTEPEJI", "ASUNCIÓN IXTALTEPEC", "ASUNCIÓN NOCHIXTLÁN", "ASUNCIÓN OCOTLÁN", 
                        "ASUNCIÓN TLACOLULITA", "AYOTZINTEPEC", "EL BARRIO DE LA SOLEDAD", "CALIHUALÁ", 
                        "CANDELARIA LOXICHA", "CIÉNEGA DE ZIMATLÁN", "CIUDAD IXTEPEC", "COATECAS ALTAS", 
                        "COICOYÁN DE LAS FLORES", "LA COMPAÑÍA", "CONCEPCIÓN BUENAVISTA", "CONCEPCIÓN PÁPALO", 
                        "CONSTANCIA DEL ROSARIO", "COSOLAPA", "COSOLTEPEC", "CUILÁPAM DE GUERRERO", 
                        "CUYAMECALCO VILLA DE ZARAGOZA", "CHAHUITES", "CHALCATONGO DE HIDALGO", 
                        "CHIQUIHUITLÁN DE BENITO JUÁREZ", "HEROICA CIUDAD DE EJUTLA DE CRESPO", 
                        "ELOXOCHITLÁN DE FLORES MAGÓN", "EL ESPINAL", "TAMAZULÁPAM DEL ESPÍRITU SANTO", 
                        "FRESNILLO DE TRUJANO", "GUADALUPE ETLA", "GUADALUPE DE RAMÍREZ", "GUELATAO DE JUÁREZ", 
                        "GUEVEA DE HUMBOLDT", "MESONES HIDALGO", "VILLA HIDALGO", "HEROICA CIUDAD DE HUAJUAPAN DE LEÓN", 
                        "HUAUTEPEC", "HUAUTLA DE JIMÉNEZ", "IXTLÁN DE JUÁREZ", "HEROICA CIUDAD DE JUCHITÁN DE ZARAGOZA", 
                        "LOMA BONITA", "MAGDALENA APASCO", "MAGDALENA JALTEPEC", "SANTA MAGDALENA JICOTLÁN", 
                        "MAGDALENA MIXTEPEC", "MAGDALENA OCOTLÁN", "MAGDALENA PEÑASCO", "MAGDALENA TEITIPAC", 
                        "MAGDALENA TEQUISISTLÁN", "MAGDALENA TLACOTEPEC", "MAGDALENA ZAHUATLÁN", "MARISCALA DE JUÁREZ", 
                        "MÁRTIRES DE TACUBAYA", "MATÍAS ROMERO AVENDAÑO", "MAZATLÁN VILLA DE FLORES", 
                        "MIAHUATLÁN DE PORFIRIO DÍAZ", "MIXISTLÁN DE LA REFORMA", "MONJAS", "NATIVIDAD", 
                        "NAZARENO ETLA", "NEJAPA DE MADERO", "IXPANTEPEC NIEVES", "SANTIAGO NILTEPEC", 
                        "OAXACA DE JUÁREZ", "OCOTLÁN DE MORELOS", "LA PE", "PINOTEPA DE DON LUIS", "PLUMA HIDALGO", 
                        "SAN JOSÉ DEL PROGRESO", "PUTLA VILLA DE GUERRERO", "SANTA CATARINA QUIOQUITANI", 
                        "REFORMA DE PINEDA", "LA REFORMA", "REYES ETLA", "ROJAS DE CUAUHTÉMOC", "SALINA CRUZ", 
                        "SAN AGUSTÍN AMATENGO", "SAN AGUSTÍN ATENANGO", "SAN AGUSTÍN CHAYUCO", 
                        "SAN AGUSTÍN DE LAS JUNTAS", "SAN AGUSTÍN ETLA", "SAN AGUSTÍN LOXICHA", 
                        "SAN AGUSTÍN TLACOTEPEC", "SAN AGUSTÍN YATARENI", "SAN ANDRÉS CABECERA NUEVA", 
                        "SAN ANDRÉS DINICUITI", "SAN ANDRÉS HUAXPALTEPEC", "SAN ANDRÉS HUAYÁPAM", 
                        "SAN ANDRÉS IXTLAHUACA", "SAN ANDRÉS LAGUNAS", "SAN ANDRÉS NUXIÑO", "SAN ANDRÉS PAXTLÁN", 
                        "SAN ANDRÉS SINAXTLA", "SAN ANDRÉS SOLAGA", "SAN ANDRÉS TEOTILÁLPAM", "SAN ANDRÉS TEPETLAPA", 
                        "SAN ANDRÉS YAÁ", "SAN ANDRÉS ZABACHE", "SAN ANDRÉS ZAUTLA", "SAN ANTONINO CASTILLO VELASCO", 
                        "SAN ANTONINO EL ALTO", "SAN ANTONINO MONTE VERDE", "SAN ANTONIO ACUTLA", 
                        "SAN ANTONIO DE LA CAL", "SAN ANTONIO HUITEPEC", "SAN ANTONIO NANAHUATÍPAM", 
                        "SAN ANTONIO SINICAHUA", "SAN ANTONIO TEPETLAPA", "SAN BALTAZAR CHICHICÁPAM", 
                        "SAN BALTAZAR LOXICHA", "SAN BALTAZAR YATZACHI EL BAJO", "SAN BARTOLO COYOTEPEC", 
                        "SAN BARTOLOMÉ AYAUTLA", "SAN BARTOLOMÉ LOXICHA", "SAN BARTOLOMÉ QUIALANA", 
                        "SAN BARTOLOMÉ YUCUAÑE", "SAN BARTOLOMÉ ZOOGOCHO", "SAN BARTOLO SOYALTEPEC", 
                        "SAN BARTOLO YAUTEPEC", "SAN BERNARDO MIXTEPEC", "SAN BLAS ATEMPA", "SAN CARLOS YAUTEPEC", 
                        "SAN CRISTÓBAL AMATLÁN", "SAN CRISTÓBAL AMOLTEPEC", "SAN CRISTÓBAL LACHIRIOAG", 
                        "SAN CRISTÓBAL SUCHIXTLAHUACA", "SAN DIONISIO DEL MAR", "SAN DIONISIO OCOTEPEC", 
                        "SAN DIONISIO OCOTLÁN", "SAN ESTEBAN ATATLAHUCA", "SAN FELIPE JALAPA DE DÍAZ", 
                        "SAN FELIPE TEJALÁPAM", "SAN FELIPE USILA", "SAN FRANCISCO CAHUACUÁ", "SAN FRANCISCO CAJONOS", 
                        "SAN FRANCISCO CHAPULAPA", "SAN FRANCISCO CHINDÚA", "SAN FRANCISCO DEL MAR", 
                        "SAN FRANCISCO HUEHUETLÁN", "SAN FRANCISCO IXHUATÁN", "SAN FRANCISCO JALTEPETONGO", 
                        "SAN FRANCISCO LACHIGOLÓ", "SAN FRANCISCO LOGUECHE", "SAN FRANCISCO NUXAÑO", 
                        "SAN FRANCISCO OZOLOTEPEC", "SAN FRANCISCO SOLA", "SAN FRANCISCO TELIXTLAHUACA",
                        "SAN FRANCISCO TEOPAN", "SAN FRANCISCO TLAPANCINGO", "SAN GABRIEL MIXTEPEC", 
                        "SAN ILDEFONSO AMATLÁN", "SAN ILDEFONSO SOLA", "SAN ILDEFONSO VILLA ALTA", 
                        "SAN JACINTO AMILPAS", "SAN JACINTO TLACOTEPEC", "SAN JERÓNIMO COATLÁN", 
                        "SAN JERÓNIMO SILACAYOAPILLA", "SAN JERÓNIMO SOSOLA", "SAN JERÓNIMO TAVICHE", 
                        "SAN JERÓNIMO TECÓATL", "SAN JORGE NUCHITA", "SAN JOSÉ AYUQUILA", "SAN JOSÉ CHILTEPEC", 
                        "SAN JOSÉ DEL PEÑASCO", "SAN JOSÉ ESTANCIA GRANDE", "SAN JOSÉ INDEPENDENCIA", 
                        "SAN JOSÉ LACHIGUIRI", "SAN JOSÉ TENANGO", "SAN JUAN ACHIUTLA", "SAN JUAN ATEPEC", 
                        "ÁNIMAS TRUJANO", "SAN JUAN BAUTISTA ATATLAHUCA", "SAN JUAN BAUTISTA COIXTLAHUACA", 
                        "SAN JUAN BAUTISTA CUICATLÁN", "SAN JUAN BAUTISTA GUELACHE", "SAN JUAN BAUTISTA JAYACATLÁN", 
                        "SAN JUAN BAUTISTA LO DE SOTO", "SAN JUAN BAUTISTA SUCHITEPEC", 
                        "SAN JUAN BAUTISTA TLACOATZINTEPEC", "SAN JUAN BAUTISTA TLACHICHILCO", 
                        "SAN JUAN BAUTISTA TUXTEPEC", "SAN JUAN CACAHUATEPEC", "SAN JUAN CIENEGUILLA", 
                        "SAN JUAN COATZÓSPAM", "SAN JUAN COLORADO", "SAN JUAN COMALTEPEC", "SAN JUAN COTZOCÓN", 
                        "SAN JUAN CHICOMEZÚCHIL", "SAN JUAN CHILATECA", "SAN JUAN DEL ESTADO", "SAN JUAN DEL RÍO", 
                        "SAN JUAN DIUXI", "SAN JUAN EVANGELISTA ANALCO", "SAN JUAN GUELAVÍA", "SAN JUAN GUICHICOVI", 
                        "SAN JUAN IHUALTEPEC", "SAN JUAN JUQUILA MIXES", "SAN JUAN JUQUILA VIJANOS", "SAN JUAN LACHAO", 
                        "SAN JUAN LACHIGALLA", "SAN JUAN LAJARCIA", "SAN JUAN LALANA", "SAN JUAN DE LOS CUÉS", 
                        "SAN JUAN MAZATLÁN", "SAN JUAN MIXTEPEC", "SAN JUAN ÑUMÍ", "SAN JUAN OZOLOTEPEC", 
                        "SAN JUAN PETLAPA", "SAN JUAN QUIAHIJE", "SAN JUAN QUIOTEPEC", "SAN JUAN SAYULTEPEC", 
                        "SAN JUAN TABAÁ", "SAN JUAN TAMAZOLA", "SAN JUAN TEITA", "SAN JUAN TEITIPAC", 
                        "SAN JUAN TEPEUXILA", "SAN JUAN TEPOSCOLULA", "SAN JUAN YAEÉ", "SAN JUAN YATZONA", 
                        "SAN JUAN YUCUITA", "SAN LORENZO", "SAN LORENZO ALBARRADAS", "SAN LORENZO CACAOTEPEC", 
                        "SAN LORENZO CUAUNECUILTITLA", "SAN LORENZO TEXMELÚCAN", "SAN LORENZO VICTORIA", 
                        "SAN LUCAS CAMOTLÁN", "SAN LUCAS OJITLÁN", "SAN LUCAS QUIAVINÍ", "SAN LUCAS ZOQUIÁPAM", 
                        "SAN LUIS AMATLÁN", "SAN MARCIAL OZOLOTEPEC", "SAN MARCOS ARTEAGA", 
                        "SAN MARTÍN DE LOS CANSECOS", "SAN MARTÍN HUAMELÚLPAM", "SAN MARTÍN ITUNYOSO", 
                        "SAN MARTÍN LACHILÁ", "SAN MARTÍN PERAS", "SAN MARTÍN TILCAJETE", "SAN MARTÍN TOXPALAN", 
                        "SAN MARTÍN ZACATEPEC", "SAN MATEO CAJONOS", "CAPULÁLPAM DE MÉNDEZ", "SAN MATEO DEL MAR", 
                        "SAN MATEO YOLOXOCHITLÁN", "SAN MATEO ETLATONGO", "SAN MATEO NEJÁPAM", "SAN MATEO PEÑASCO", 
                        "SAN MATEO PIÑAS", "SAN MATEO RÍO HONDO", "SAN MATEO SINDIHUI", "SAN MATEO TLAPILTEPEC", 
                        "SAN MELCHOR BETAZA", "SAN MIGUEL ACHIUTLA", "SAN MIGUEL AHUEHUETITLÁN", "SAN MIGUEL ALOÁPAM", 
                        "SAN MIGUEL AMATITLÁN", "SAN MIGUEL AMATLÁN", "SAN MIGUEL COATLÁN", "SAN MIGUEL CHICAHUA", 
                        "SAN MIGUEL CHIMALAPA", "SAN MIGUEL DEL PUERTO", "SAN MIGUEL DEL RÍO", "SAN MIGUEL EJUTLA", 
                        "SAN MIGUEL EL GRANDE", "SAN MIGUEL HUAUTLA", "SAN MIGUEL MIXTEPEC", "SAN MIGUEL PANIXTLAHUACA", 
                        "SAN MIGUEL PERAS", "SAN MIGUEL PIEDRAS", "SAN MIGUEL QUETZALTEPEC", "SAN MIGUEL SANTA FLOR", 
                        "VILLA SOLA DE VEGA", "SAN MIGUEL SOYALTEPEC", "SAN MIGUEL SUCHIXTEPEC", "VILLA TALEA DE CASTRO", 
                        "SAN MIGUEL TECOMATLÁN", "SAN MIGUEL TENANGO", "SAN MIGUEL TEQUIXTEPEC", "SAN MIGUEL TILQUIÁPAM", 
                        "SAN MIGUEL TLACAMAMA", "SAN MIGUEL TLACOTEPEC", "SAN MIGUEL TULANCINGO", "SAN MIGUEL YOTAO", 
                        "SAN NICOLÁS", "SAN NICOLÁS HIDALGO", "SAN PABLO COATLÁN", "SAN PABLO CUATRO VENADOS", 
                        "SAN PABLO ETLA", "SAN PABLO HUITZO", "SAN PABLO HUIXTEPEC", "SAN PABLO MACUILTIANGUIS", 
                        "SAN PABLO TIJALTEPEC", "SAN PABLO VILLA DE MITLA", "SAN PABLO YAGANIZA", "SAN PEDRO AMUZGOS", 
                        "SAN PEDRO APÓSTOL", "SAN PEDRO ATOYAC", "SAN PEDRO CAJONOS", "SAN PEDRO COXCALTEPEC CÁNTAROS", 
                        "SAN PEDRO COMITANCILLO", "SAN PEDRO EL ALTO", "SAN PEDRO HUAMELULA", "SAN PEDRO HUILOTEPEC", 
                        "SAN PEDRO IXCATLÁN", "SAN PEDRO IXTLAHUACA", "SAN PEDRO JALTEPETONGO", "SAN PEDRO JICAYÁN", 
                        "SAN PEDRO JOCOTIPAC", "SAN PEDRO JUCHATENGO", "SAN PEDRO MÁRTIR", "SAN PEDRO MÁRTIR QUIECHAPA", 
                        "SAN PEDRO MÁRTIR YUCUXACO", "SAN PEDRO MIXTEPEC", "SAN PEDRO MIXTEPEC", "SAN PEDRO MOLINOS", 
                        "SAN PEDRO NOPALA", "SAN PEDRO OCOPETATILLO", "SAN PEDRO OCOTEPEC", "SAN PEDRO POCHUTLA", 
                        "SAN PEDRO QUIATONI", "SAN PEDRO SOCHIÁPAM", "SAN PEDRO TAPANATEPEC", "SAN PEDRO TAVICHE", 
                        "SAN PEDRO TEOZACOALCO", "SAN PEDRO TEUTILA", "SAN PEDRO TIDAÁ", "SAN PEDRO TOPILTEPEC", 
                        "SAN PEDRO TOTOLÁPAM", "VILLA DE TUTUTEPEC", "SAN PEDRO YANERI", "SAN PEDRO YÓLOX", 
                        "SAN PEDRO Y SAN PABLO AYUTLA", "VILLA DE ETLA", "SAN PEDRO Y SAN PABLO TEPOSCOLULA", 
                        "SAN PEDRO Y SAN PABLO TEQUIXTEPEC", "SAN PEDRO YUCUNAMA", "SAN RAYMUNDO JALPAN", 
                        "SAN SEBASTIÁN ABASOLO", "SAN SEBASTIÁN COATLÁN", "SAN SEBASTIÁN IXCAPA", 
                        "SAN SEBASTIÁN NICANANDUTA", "SAN SEBASTIÁN RÍO HONDO", "SAN SEBASTIÁN TECOMAXTLAHUACA", 
                        "SAN SEBASTIÁN TEITIPAC", "SAN SEBASTIÁN TUTLA", "SAN SIMÓN ALMOLONGAS", "SAN SIMÓN ZAHUATLÁN", 
                        "SANTA ANA", "SANTA ANA ATEIXTLAHUACA", "SANTA ANA CUAUHTÉMOC", "SANTA ANA DEL VALLE", 
                        "SANTA ANA TAVELA", "SANTA ANA TLAPACOYAN", "SANTA ANA YARENI", "SANTA ANA ZEGACHE", 
                        "SANTA CATALINA QUIERÍ", "SANTA CATARINA CUIXTLA", "SANTA CATARINA IXTEPEJI", 
                        "SANTA CATARINA JUQUILA", "SANTA CATARINA LACHATAO", "SANTA CATARINA LOXICHA", 
                        "SANTA CATARINA MECHOACÁN", "SANTA CATARINA MINAS", "SANTA CATARINA QUIANÉ", 
                        "SANTA CATARINA TAYATA", "SANTA CATARINA TICUÁ", "SANTA CATARINA YOSONOTÚ", 
                        "SANTA CATARINA ZAPOQUILA", "SANTA CRUZ ACATEPEC", "SANTA CRUZ AMILPAS", "SANTA CRUZ DE BRAVO", 
                        "SANTA CRUZ ITUNDUJIA", "SANTA CRUZ MIXTEPEC", "SANTA CRUZ NUNDACO", "SANTA CRUZ PAPALUTLA", 
                        "SANTA CRUZ TACACHE DE MINA", "SANTA CRUZ TACAHUA", "SANTA CRUZ TAYATA", "SANTA CRUZ XITLA", 
                        "SANTA CRUZ XOXOCOTLÁN", "SANTA CRUZ ZENZONTEPEC", "SANTA GERTRUDIS", "SANTA INÉS DEL MONTE", 
                        "SANTA INÉS YATZECHE", "SANTA LUCÍA DEL CAMINO", "SANTA LUCÍA MIAHUATLÁN", 
                        "SANTA LUCÍA MONTEVERDE", "SANTA LUCÍA OCOTLÁN", "SANTA MARÍA ALOTEPEC", "SANTA MARÍA APAZCO", 
                        "SANTA MARÍA LA ASUNCIÓN", "HEROICA CIUDAD DE TLAXIACO", "AYOQUEZCO DE ALDAMA", 
                        "SANTA MARÍA ATZOMPA", "SANTA MARÍA CAMOTLÁN", "SANTA MARÍA COLOTEPEC", "SANTA MARÍA CORTIJO", 
                        "SANTA MARÍA COYOTEPEC", "SANTA MARÍA CHACHOÁPAM", "VILLA DE CHILAPA DE DÍAZ", 
                        "SANTA MARÍA CHILCHOTLA", "SANTA MARÍA CHIMALAPA", "SANTA MARÍA DEL ROSARIO", 
                        "SANTA MARÍA DEL TULE", "SANTA MARÍA ECATEPEC", "SANTA MARÍA GUELACÉ", "SANTA MARÍA GUIENAGATI", 
                        "SANTA MARÍA HUATULCO", "SANTA MARÍA HUAZOLOTITLÁN", "SANTA MARÍA IPALAPA", "SANTA MARÍA IXCATLÁN", 
                        "SANTA MARÍA JACATEPEC", "SANTA MARÍA JALAPA DEL MARQUÉS", "SANTA MARÍA JALTIANGUIS", "SANTA MARÍA LACHIXÍO", 
                        "SANTA MARÍA MIXTEQUILLA", "SANTA MARÍA NATIVITAS", "SANTA MARÍA NDUAYACO", "SANTA MARÍA OZOLOTEPEC", 
                        "SANTA MARÍA PÁPALO", "SANTA MARÍA PEÑOLES", "SANTA MARÍA PETAPA", "SANTA MARÍA QUIEGOLANI", 
                        "SANTA MARÍA SOLA", "SANTA MARÍA TATALTEPEC", "SANTA MARÍA TECOMAVACA", "SANTA MARÍA TEMAXCALAPA", 
                        "SANTA MARÍA TEMAXCALTEPEC", "SANTA MARÍA TEOPOXCO", "SANTA MARÍA TEPANTLALI", "SANTA MARÍA TEXCATITLÁN", 
                        "SANTA MARÍA TLAHUITOLTEPEC", "SANTA MARÍA TLALIXTAC", "SANTA MARÍA TONAMECA", "SANTA MARÍA TOTOLAPILLA", 
                        "SANTA MARÍA XADANI", "SANTA MARÍA YALINA", "SANTA MARÍA YAVESÍA", "SANTA MARÍA YOLOTEPEC", 
                        "SANTA MARÍA YOSOYÚA", "SANTA MARÍA YUCUHITI", "SANTA MARÍA ZACATEPEC", "SANTA MARÍA ZANIZA", 
                        "SANTA MARÍA ZOQUITLÁN", "SANTIAGO AMOLTEPEC", "SANTIAGO APOALA", "SANTIAGO APÓSTOL", "SANTIAGO ASTATA", 
                        "SANTIAGO ATITLÁN", "SANTIAGO AYUQUILILLA", "SANTIAGO CACALOXTEPEC", "SANTIAGO CAMOTLÁN", 
                        "SANTIAGO COMALTEPEC", "SANTIAGO CHAZUMBA", "SANTIAGO CHOÁPAM", "SANTIAGO DEL RÍO", 
                        "SANTIAGO HUAJOLOTITLÁN", "SANTIAGO HUAUCLILLA", "SANTIAGO IHUITLÁN PLUMAS", "SANTIAGO IXCUINTEPEC", 
                        "SANTIAGO IXTAYUTLA", "SANTIAGO JAMILTEPEC", "SANTIAGO JOCOTEPEC", "SANTIAGO JUXTLAHUACA", 
                        "SANTIAGO LACHIGUIRI", "SANTIAGO LALOPA", "SANTIAGO LAOLLAGA", "SANTIAGO LAXOPA", 
                        "SANTIAGO LLANO GRANDE", "SANTIAGO MATATLÁN", "SANTIAGO MILTEPEC", "SANTIAGO MINAS", "SANTIAGO NACALTEPEC", 
                        "SANTIAGO NEJAPILLA", "SANTIAGO NUNDICHE", "SANTIAGO NUYOÓ", "SANTIAGO PINOTEPA NACIONAL", "SANTIAGO SUCHILQUITONGO", 
                        "SANTIAGO TAMAZOLA", "SANTIAGO TAPEXTLA", "VILLA TEJÚPAM DE LA UNIÓN", "SANTIAGO TENANGO", 
                        "SANTIAGO TEPETLAPA", "SANTIAGO TETEPEC", "SANTIAGO TEXCALCINGO", "SANTIAGO TEXTITLÁN", 
                        "SANTIAGO TILANTONGO", "SANTIAGO TILLO", "SANTIAGO TLAZOYALTEPEC", "SANTIAGO XANICA", "SANTIAGO XIACUÍ", 
                        "SANTIAGO YAITEPEC", "SANTIAGO YAVEO", "SANTIAGO YOLOMÉCATL", "SANTIAGO YOSONDÚA", "SANTIAGO YUCUYACHI", 
                        "SANTIAGO ZACATEPEC", "SANTIAGO ZOOCHILA", "NUEVO ZOQUIÁPAM", "SANTO DOMINGO INGENIO", 
                        "SANTO DOMINGO ALBARRADAS", "SANTO DOMINGO ARMENTA", "SANTO DOMINGO CHIHUITÁN", "SANTO DOMINGO DE MORELOS", 
                        "SANTO DOMINGO IXCATLÁN", "SANTO DOMINGO NUXAÁ", "SANTO DOMINGO OZOLOTEPEC", 
                        "SANTO DOMINGO PETAPA", "SANTO DOMINGO ROAYAGA", "SANTO DOMINGO TEHUANTEPEC", "SANTO DOMINGO TEOJOMULCO", 
                        "SANTO DOMINGO TEPUXTEPEC", "SANTO DOMINGO TLATAYÁPAM", "SANTO DOMINGO TOMALTEPEC", 
                        "SANTO DOMINGO TONALÁ", "SANTO DOMINGO TONALTEPEC", "SANTO DOMINGO XAGACÍA", 
                        "SANTO DOMINGO YANHUITLÁN", "SANTO DOMINGO YODOHINO", "SANTO DOMINGO ZANATEPEC", "SANTOS REYES NOPALA", 
                        "SANTOS REYES PÁPALO", "SANTOS REYES TEPEJILLO", "SANTOS REYES YUCUNÁ", "SANTO TOMÁS JALIEZA", 
                        "SANTO TOMÁS MAZALTEPEC", "SANTO TOMÁS OCOTEPEC", "SANTO TOMÁS TAMAZULAPAN", 
                        "SAN VICENTE COATLÁN", "SAN VICENTE LACHIXÍO", "SAN VICENTE NUÑÚ", "SILACAYOÁPAM", 
                        "SITIO DE XITLAPEHUA", "SOLEDAD ETLA", "VILLA DE TAMAZULÁPAM DEL PROGRESO", 
                        "TANETZE DE ZARAGOZA", "TANICHE", "TATALTEPEC DE VALDÉS", "TEOCOCUILCO DE MARCOS PÉREZ", 
                        "TEOTITLÁN DE FLORES MAGÓN", "TEOTITLÁN DEL VALLE", "TEOTONGO", "TEPELMEME VILLA DE MORELOS", 
                        "VILLA TEZOATLÁN DE SEGURA Y LUNA", "SAN JERÓNIMO TLACOCHAHUAYA", "TLACOLULA DE MATAMOROS", 
                        "TLACOTEPEC PLUMAS", "TLALIXTAC DE CABRERA", "TOTONTEPEC VILLA DE MORELOS", "TRINIDAD ZAACHILA", 
                        "LA TRINIDAD VISTA HERMOSA", "UNIÓN HIDALGO", "VALERIO TRUJANO", "SAN JUAN BAUTISTA VALLE NACIONAL", 
                        "VILLA DÍAZ ORDAZ", "YAXE", "MAGDALENA YODOCONO DE PORFIRIO DÍAZ", "YOGANA", "YUTANDUCHI DE GUERRERO", 
                        "VILLA DE ZAACHILA", "SAN MATEO YUCUTINDOO", "ZAPOTITLÁN LAGUNAS", "ZAPOTITLÁN PALMAS", 
                        "SANTA INÉS DE ZARAGOZA", "ZIMATLÁN DE ÁLVAREZ" };
                    break;
                }
                case 21: // Puebla
                {
                    cities = new string[] {"Seleccionar",  "ACAJETE", "ACATENO", "ACATLÁN", "ACATZINGO", "ACTEOPAN",
                        "AHUACATLÁN", "AHUATLÁN", "AHUAZOTEPEC", "AHUEHUETITLA", "AJALPAN",
                        "ALBINO ZERTUCHE", "ALJOJUCA", "ALTEPEXI", "AMIXTLÁN", "AMOZOC", "AQUIXTLA",
                        "ATEMPAN", "ATEXCAL", "ATLIXCO", "ATOYATEMPAN", "ATZALA", "ATZITZIHUACÁN",
                        "ATZITZINTLA", "AXUTLA", "AYOTOXCO DE GUERRERO", "CALPAN", "CALTEPEC",
                        "CAMOCUAUTLA", "CAXHUACAN", "COATEPEC", "COATZINGO", "COHETZALA", "COHUECAN",
                        "CORONANGO", "COXCATLÁN", "COYOMEAPAN", "COYOTEPEC", "CUAPIAXTLA DE MADERO",
                        "CUAUTEMPAN", "CUAUTINCHÁN", "CUAUTLANCINGO", "CUAYUCA DE ANDRADE",
                        "CUETZALAN DEL PROGRESO", "CUYOACO", "CHALCHICOMULA DE SESMA", "CHAPULCO",
                        "CHIAUTLA", "CHIAUTZINGO", "CHICONCUAUTLA", "CHICHIQUILA", "CHIETLA",
                        "CHIGMECATITLÁN", "CHIGNAHUAPAN", "CHIGNAUTLA", "CHILA", "CHILA DE LA SAL",
                        "HONEY", "CHILCHOTLA", "CHINANTLA", "DOMINGO ARENAS", "ELOXOCHITLÁN", "EPATLÁN",
                        "ESPERANZA", "FRANCISCO Z. MENA", "GENERAL FELIPE ÁNGELES", "GUADALUPE",
                        "GUADALUPE VICTORIA", "HERMENEGILDO GALEANA", "HUAQUECHULA", "HUATLATLAUCA",
                        "HUAUCHINANGO", "HUEHUETLA", "HUEHUETLÁN EL CHICO", "HUEJOTZINGO", "HUEYAPAN",
                        "HUEYTAMALCO", "HUEYTLALPAN", "HUITZILAN DE SERDÁN", "HUITZILTEPEC",
                        "ATLEQUIZAYAN", "IXCAMILPA DE GUERRERO", "IXCAQUIXTLA", "IXTACAMAXTITLÁN",
                        "IXTEPEC", "IZÚCAR DE MATAMOROS", "JALPAN", "JOLALPAN", "JONOTLA", "JOPALA",
                        "JUAN C. BONILLA", "JUAN GALINDO", "JUAN N. MÉNDEZ", "LAFRAGUA", "LIBRES",
                        "LA MAGDALENA TLATLAUQUITEPEC", "MAZAPILTEPEC DE JUÁREZ", "MIXTLA", "MOLCAXAC",
                        "CAÑADA MORELOS", "NAUPAN", "NAUZONTLA", "NEALTICAN", "NICOLÁS BRAVO",
                        "NOPALUCAN", "OCOTEPEC", "OCOYUCAN", "OLINTLA", "ORIENTAL", "PAHUATLÁN",
                        "PALMAR DE BRAVO", "PANTEPEC", "PETLALCINGO", "PIAXTLA", "PUEBLA", "QUECHOLAC",
                        "QUIMIXTLÁN", "RAFAEL LARA GRAJALES", "LOS REYES DE JUÁREZ", "SAN ANDRÉS CHOLULA",
                        "SAN ANTONIO CAÑADA", "SAN DIEGO LA MESA TOCHIMILTZINGO",
                        "SAN FELIPE TEOTLALCINGO", "SAN FELIPE TEPATLÁN", "SAN GABRIEL CHILAC",
                        "SAN GREGORIO ATZOMPA", "SAN JERÓNIMO TECUANIPAN", "SAN JERÓNIMO XAYACATLÁN", 
                        "SAN JOSÉ CHIAPA", "SAN JOSÉ MIAHUATLÁN", "SAN JUAN ATENCO", "SAN JUAN ATZOMPA", 
                        "SAN MARTÍN TEXMELUCAN", "SAN MARTÍN TOTOLTEPEC", "SAN MATÍAS TLALANCALECA", 
                        "SAN MIGUEL IXITLÁN", "SAN MIGUEL XOXTLA", "SAN NICOLÁS BUENOS AIRES", 
                        "SAN NICOLÁS DE LOS RANCHOS", "SAN PABLO ANICANO", "SAN PEDRO CHOLULA", 
                        "SAN PEDRO YELOIXTLAHUACA", "SAN SALVADOR EL SECO", "SAN SALVADOR EL VERDE", 
                        "SAN SALVADOR HUIXCOLOTLA", "SAN SEBASTIÁN TLACOTEPEC", 
                        "SANTA CATARINA TLALTEMPAN", "SANTA INÉS AHUATEMPAN", "SANTA ISABEL CHOLULA", 
                        "SANTIAGO MIAHUATLÁN", "HUEHUETLÁN EL GRANDE", "SANTO TOMÁS HUEYOTLIPAN", 
                        "SOLTEPEC", "TECALI DE HERRERA", "TECAMACHALCO", "TECOMATLÁN", "TEHUACÁN", 
                        "TEHUITZINGO", "TENAMPULCO", "TEOPANTLÁN", "TEOTLALCO", "TEPANCO DE LÓPEZ", 
                        "TEPANGO DE RODRÍGUEZ", "TEPATLAXCO DE HIDALGO", "TEPEACA", "TEPEMAXALCO", 
                        "TEPEOJUMA", "TEPETZINTLA", "TEPEXCO", "TEPEXI DE RODRÍGUEZ", "TEPEYAHUALCO", 
                        "TEPEYAHUALCO DE CUAUHTÉMOC", "TETELA DE OCAMPO", "TETELES DE AVILA CASTILLO", 
                        "TEZIUTLÁN", "TIANGUISMANALCO", "TILAPA", "TLACOTEPEC DE BENITO JUÁREZ", 
                        "TLACUILOTEPEC", "TLACHICHUCA", "TLAHUAPAN", "TLALTENANGO", "TLANEPANTLA", 
                        "TLAOLA", "TLAPACOYA", "TLAPANALÁ", "TLATLAUQUITEPEC", "TLAXCO", "TOCHIMILCO", 
                        "TOCHTEPEC", "TOTOLTEPEC DE GUERRERO", "TULCINGO", "TUZAMAPAN DE GALEANA", 
                        "TZICATLACOYAN", "VENUSTIANO CARRANZA", "VICENTE GUERRERO", 
                        "XAYACATLÁN DE BRAVO", "XICOTEPEC", "XICOTLÁN", "XIUTETELCO", "XOCHIAPULCO", 
                        "XOCHILTEPEC", "XOCHITLÁN DE VICENTE SUÁREZ", "XOCHITLÁN TODOS SANTOS", 
                        "YAONÁHUAC", "YEHUALTEPEC", "ZACAPALA", "ZACAPOAXTLA", "ZACATLÁN", "ZAPOTITLÁN", 
                        "ZAPOTITLÁN DE MÉNDEZ", "ZARAGOZA", "ZAUTLA", "ZIHUATEUTLA", "ZINACATEPEC", 
                        "ZONGOZOTLA", "ZOQUIAPAN", "ZOQUITLÁN" };
                    break;
                }
                case 22: // Querétaro
                {
                    cities = new string[] { "Seleccionar", "AMEALCO DE BONFIL", "PINAL DE AMOLES", "ARROYO SECO", "CADEREYTA DE MONTES", 
                        "COLÓN", "CORREGIDORA", "EZEQUIEL MONTES", "HUIMILPAN", "JALPAN DE SERRA", "LANDA DE MATAMOROS", 
                        "EL MARQUÉS", "PEDRO ESCOBEDO", "PEÑAMILLER", "QUERÉTARO", "SAN JOAQUÍN", "SAN JUAN DEL RÍO", 
                        "TEQUISQUIAPAN", "TOLIMÁN" };
                    break;
                }
                case 23: // Quintana Roo
                {
                    cities = new string[] { "Seleccionar", "COZUMEL", "FELIPE CARRILLO PUERTO", "ISLA MUJERES", "OTHÓN P. BLANCO", 
                        "BENITO JUÁREZ", "JOSÉ MARÍA MORELOS", "LÁZARO CÁRDENAS", "SOLIDARIDAD", "TULUM", "BACALAR", 
                        "PUERTO MORELOS" };
                    break;
                }
                case 24: // San Luis Potosí
                {
                    cities = new string[] { "Seleccionar", "AHUALULCO", "ALAQUINES", "AQUISMÓN", "ARMADILLO DE LOS INFANTE",
                        "AXTLA DE TERRAZAS", "CÁRDENAS", "CATORCE", "CEDRAL", "CERRITOS", "CERRO DE SAN PEDRO",
                        "CIUDAD DEL MAÍZ", "CIUDAD FERNÁNDEZ", "TANCANHUITZ", "CIUDAD VALLES", "COXCATLÁN", "CHARCAS",
                        "EBANO", "GUADALCÁZAR", "HUEHUETLÁN", "LAGUNILLAS", "MATEHUALA", "MATLAPA", "MEXQUITIC DE CARMONA",
                        "MOCTEZUMA", "EL NARANJO", "RAYÓN", "RIOVERDE", "SALINAS", "SAN ANTONIO", "SAN CIRO DE ACOSTA",
                        "SAN LUIS POTOSÍ", "SAN MARTÍN CHALCHICUAUTLA", "SAN NICOLÁS TOLENTINO", "SANTA CATARINA",
                        "SANTA MARÍA DEL RÍO", "SANTO DOMINGO", "SAN VICENTE TANCUAYALAB", "SOLEDAD DE GRACIANO SÁNCHEZ",
                        "TAMASOPO", "TAMAZUNCHALE", "TAMPACÁN", "TAMPAMOLÓN CORONA", "TAMUÍN", "TANLAJÁS",
                        "TANQUIÁN DE ESCOBEDO", "TIERRA NUEVA", "VANEGAS", "VENADO", "VILLA DE ARRIAGA", "VILLA DE ARISTA",
                        "VILLA DE GUADALUPE", "VILLA DE LA PAZ", "VILLA DE RAMOS", "VILLA DE REYES", "VILLA HIDALGO",
                        "VILLA JUÁREZ", "XILITLA", "ZARAGOZA" };
                    break;
                }
                case 25: // Sinaloa
                {
                    cities = new string[] { "Seleccionar", "AHOME", "ANGOSTURA", "BADIRAGUATO", "CONCORDIA", "COSALÁ", "CULIACÁN", 
                        "CHOIX", "ELOTA", "ESCUINAPA", "EL FUERTE", "GUASAVE", "MAZATLÁN", "MOCORITO", "ROSARIO", 
                        "SALVADOR ALVARADO", "SAN IGNACIO", "SINALOA", "NAVOLATO" };
                    break;
                }
                case 26: // Sonora 
                {
                    cities = new string[] {"Seleccionar",  "ACONCHI", "AGUA PRIETA", "ALAMOS", "ALTAR", "ARIVECHI", "ARIZPE", "ATIL", 
                        "BACADÉHUACHI", "BACANORA", "BACERAC", "BACOACHI", "BÁCUM", "BANÁMICHI", "BAVIÁCORA", 
                        "BAVISPE", "BENJAMÍN HILL", "CABORCA", "CAJEME", "CANANEA", "CARBÓ", "LA COLORADA", "CUCURPE", 
                        "CUMPAS", "DIVISADEROS", "EMPALME", "ETCHOJOA", "FRONTERAS", "GRANADOS", "GUAYMAS", 
                        "HERMOSILLO", "HUACHINERA", "HUÁSABAS", "HUATABAMPO", "HUÉPAC", "IMURIS", "MAGDALENA", 
                        "MAZATÁN", "MOCTEZUMA", "NACO", "NÁCORI CHICO", "NACOZARI DE GARCÍA", "NAVOJOA", "NOGALES", 
                        "ONAVAS", "OPODEPE", "OQUITOA", "PITIQUITO", "PUERTO PEÑASCO", "QUIRIEGO", "RAYÓN", "ROSARIO", 
                        "SAHUARIPA", "SAN FELIPE DE JESÚS", "SAN JAVIER", "SAN LUIS RÍO COLORADO", 
                        "SAN MIGUEL DE HORCASITAS", "SAN PEDRO DE LA CUEVA", "SANTA ANA", "SANTA CRUZ", "SÁRIC", 
                        "SOYOPA", "SUAQUI GRANDE", "TEPACHE", "TRINCHERAS", "TUBUTAMA", "URES", "VILLA HIDALGO", 
                        "VILLA PESQUEIRA", "YÉCORA", "GENERAL PLUTARCO ELÍAS CALLES", "BENITO JUÁREZ", 
                        "SAN IGNACIO RÍO MUERTO" };
                    break;
                }
                case 27: // Tabasco
                {
                    cities = new string[] {"Seleccionar",  "BALANCÁN", "CÁRDENAS", "CENTLA", "CENTRO", "COMALCALCO", "CUNDUACÁN", 
                        "EMILIANO ZAPATA", "HUIMANGUILLO", "JALAPA", "JALPA DE MÉNDEZ", "JONUTA", "MACUSPANA", "NACAJUCA", 
                        "PARAÍSO", "TACOTALPA", "TEAPA", "TENOSIQUE" };
                    break;
                }
                case 28: // Tamaulipas
                {
                    cities = new string[] {"Seleccionar",  "ABASOLO", "ALDAMA", "ALTAMIRA", "ANTIGUO MORELOS",
                    "BURGOS", "BUSTAMANTE", "CAMARGO", "CASAS", "CIUDAD MADERO", "CRUILLAS",
                    "GÓMEZ FARÍAS", "GONZÁLEZ", "GÜÉMEZ", "GUERRERO", "GUSTAVO DÍAZ ORDAZ", "HIDALGO",
                    "JAUMAVE", "JIMÉNEZ", "LLERA", "MAINERO", "EL MANTE", "MATAMOROS", "MÉNDEZ", "MIER",
                    "MIGUEL ALEMÁN", "MIQUIHUANA", "NUEVO LAREDO", "NUEVO MORELOS", "OCAMPO", "PADILLA",
                    "PALMILLAS", "REYNOSA", "RÍO BRAVO", "SAN CARLOS", "SAN FERNANDO", "SAN NICOLÁS", 
                        "SOTO LA MARINA", "TAMPICO", "TULA", "VALLE HERMOSO", "VICTORIA", "VILLAGRÁN", 
                        "XICOTÉNCATL" };
                    break;
                }
                case 29: // Tlaxcala
                {
                    cities = new string[] {"Seleccionar",  "AMAXAC DE GUERRERO", "APETATITLÁN DE ANTONIO CARVAJAL",
                    "ATLANGATEPEC", "ATLTZAYANCA", "APIZACO", "CALPULALPAN", "EL CARMEN TEQUEXQUITLA",
                    "CUAPIAXTLA", "CUAXOMULCO", "CHIAUTEMPAN", "MUÑOZ DE DOMINGO ARENAS", "ESPAÑITA",
                    "HUAMANTLA", "HUEYOTLIPAN", "IXTACUIXTLA DE MARIANO MATAMOROS", "IXTENCO",
                    "MAZATECOCHCO DE JOSÉ MARÍA MORELOS", "CONTLA DE JUAN CUAMATZI",
                    "TEPETITLA DE LARDIZÁBAL", "SANCTÓRUM DE LÁZARO CÁRDENAS",
                    "NANACAMILPA DE MARIANO ARISTA", "ACUAMANALA DE MIGUEL HIDALGO", "NATÍVITAS",
                    "PANOTLA", "SAN PABLO DEL MONTE", "SANTA CRUZ TLAXCALA", "TENANCINGO", "TEOLOCHOLCO",
                    "TEPEYANCO", "TERRENATE", "TETLA DE LA SOLIDARIDAD", "TETLATLAHUCA", "TLAXCALA",
                    "TLAXCO", "TOCATLÁN", "TOTOLAC", "ZILTLALTÉPEC DE TRINIDAD SÁNCHEZ SANTOS",
                    "TZOMPANTEPEC", "XALOZTOC", "XALTOCAN", "PAPALOTLA DE XICOHTÉNCATL", "XICOHTZINCO",
                    "YAUHQUEMEHCAN", "ZACATELCO", "BENITO JUÁREZ", "EMILIANO ZAPATA", "LÁZARO CÁRDENAS",
                    "LA MAGDALENA TLALTELULCO", "SAN DAMIÁN TEXÓLOC", "SAN FRANCISCO TETLANOHCAN",
                        "SAN JERÓNIMO ZACUALPAN", "SAN JOSÉ TEACALCO", "SAN JUAN HUACTZINCO",
                        "SAN LORENZO AXOCOMANITLA", "SAN LUCAS TECOPILCO", "SANTA ANA NOPALUCAN", 
                        "SANTA APOLONIA TEACALCO", "SANTA CATARINA AYOMETLA", "SANTA CRUZ QUILEHTLA", 
                        "SANTA ISABEL XILOXOXTLA" };
                    break;
                }
                case 30: // Veracruz
                {
                    cities = new string[] {"Seleccionar",  "ACAJETE", "ACATLÁN", "ACAYUCAN", "ACTOPAN", "ACULA", 
                        "ACULTZINGO", "CAMARÓN DE TEJEDA", "ALPATLÁHUAC", 
                        "ALTO LUCERO DE GUTIÉRREZ BARRIOS", "ALTOTONGA", "ALVARADO", "AMATITLÁN", 
                        "NARANJOS AMATLÁN", "AMATLÁN DE LOS REYES", "ANGEL R. CABADA", "LA ANTIGUA", 
                        "APAZAPAN", "AQUILA", "ASTACINGA", "ATLAHUILCO", "ATOYAC", "ATZACAN", "ATZALAN", 
                        "TLALTETELA", "AYAHUALULCO", "BANDERILLA", "BENITO JUÁREZ", "BOCA DEL RÍO", 
                        "CALCAHUALCO", "CAMERINO Z. MENDOZA", "CARRILLO PUERTO", "CATEMACO", 
                        "CAZONES DE HERRERA", "CERRO AZUL", "CITLALTÉPETL", "COACOATZINTLA", 
                        "COAHUITLÁN", "COATEPEC", "COATZACOALCOS", "COATZINTLA", "COETZALA", "COLIPA", 
                        "COMAPA", "CÓRDOBA", "COSAMALOAPAN DE CARPIO", "COSAUTLÁN DE CARVAJAL", 
                        "COSCOMATEPEC", "COSOLEACAQUE", "COTAXTLA", "COXQUIHUI", "COYUTLA", "CUICHAPA", 
                        "CUITLÁHUAC", "CHACALTIANGUIS", "CHALMA", "CHICONAMEL", "CHICONQUIACO", 
                        "CHICONTEPEC", "CHINAMECA", "CHINAMPA DE GOROSTIZA", "LAS CHOAPAS", "CHOCAMÁN", 
                        "CHONTLA", "CHUMATLÁN", "EMILIANO ZAPATA", "ESPINAL", "FILOMENO MATA", "FORTÍN", 
                        "GUTIÉRREZ ZAMORA", "HIDALGOTITLÁN", "HUATUSCO", "HUAYACOCOTLA", 
                        "HUEYAPAN DE OCAMPO", "HUILOAPAN DE CUAUHTÉMOC", "IGNACIO DE LA LLAVE", 
                        "ILAMATLÁN", "ISLA", "IXCATEPEC", "IXHUACÁN DE LOS REYES", "IXHUATLÁN DEL CAFÉ", 
                        "IXHUATLANCILLO", "IXHUATLÁN DEL SURESTE", "IXHUATLÁN DE MADERO", "IXMATLAHUACAN", 
                        "IXTACZOQUITLÁN", "JALACINGO", "XALAPA", "JALCOMULCO", "JÁLTIPAN", "JAMAPA", 
                        "JESÚS CARRANZA", "XICO", "JILOTEPEC", "JUAN RODRÍGUEZ CLARA", 
                        "JUCHIQUE DE FERRER", "LANDERO Y COSS", "LERDO DE TEJADA", "MAGDALENA", 
                        "MALTRATA", "MANLIO FABIO ALTAMIRANO", "MARIANO ESCOBEDO", 
                        "MARTÍNEZ DE LA TORRE", "MECATLÁN", "MECAYAPAN", "MEDELLÍN DE BRAVO", 
                        "MIAHUATLÁN", "LAS MINAS", "MINATITLÁN", "MISANTLA", "MIXTLA DE ALTAMIRANO", 
                        "MOLOACÁN", "NAOLINCO", "NARANJAL", "NAUTLA", "NOGALES", "OLUTA", "OMEALCA", 
                        "ORIZABA", "OTATITLÁN", "OTEAPAN", "OZULUAMA DE MASCAREÑAS", "PAJAPAN", "PÁNUCO", 
                        "PAPANTLA", "PASO DEL MACHO", "PASO DE OVEJAS", "LA PERLA", "PEROTE", 
                        "PLATÓN SÁNCHEZ", "PLAYA VICENTE", "POZA RICA DE HIDALGO", 
                        "LAS VIGAS DE RAMÍREZ", "PUEBLO VIEJO", "PUENTE NACIONAL", "RAFAEL DELGADO", 
                        "RAFAEL LUCIO", "LOS REYES", "RÍO BLANCO", "SALTABARRANCA", 
                        "SAN ANDRÉS TENEJAPAN", "SAN ANDRÉS TUXTLA", "SAN JUAN EVANGELISTA", 
                        "SANTIAGO TUXTLA", "SAYULA DE ALEMÁN", "SOCONUSCO", "SOCHIAPA", 
                        "SOLEDAD ATZOMPA", "SOLEDAD DE DOBLADO", "SOTEAPAN", "TAMALÍN", "TAMIAHUA", 
                        "TAMPICO ALTO", "TANCOCO", "TANTIMA", "TANTOYUCA", "TATATILA", 
                        "CASTILLO DE TEAYO", "TECOLUTLA", "TEHUIPANGO", "ÁLAMO TEMAPACHE", "TEMPOAL", 
                        "TENAMPA", "TENOCHTITLÁN", "TEOCELO", "TEPATLAXCO", "TEPETLÁN", "TEPETZINTLA", 
                        "TEQUILA", "JOSÉ AZUETA", "TEXCATEPEC", "TEXHUACÁN", "TEXISTEPEC", "TEZONAPA", 
                        "TIERRA BLANCA", "TIHUATLÁN", "TLACOJALPAN", "TLACOLULAN", "TLACOTALPAN", 
                        "TLACOTEPEC DE MEJÍA", "TLACHICHILCO", "TLALIXCOYAN", "TLALNELHUAYOCAN", 
                        "TLAPACOYAN", "TLAQUILPA", "TLILAPAN", "TOMATLÁN", "TONAYÁN", "TOTUTLA", "TUXPAN", 
                        "TUXTILLA", "URSULO GALVÁN", "VEGA DE ALATORRE", "VERACRUZ", "VILLA ALDAMA", 
                        "XOXOCOTLA", "YANGA", "YECUATLA", "ZACUALPAN", "ZARAGOZA", "ZENTLA", "ZONGOLICA", 
                        "ZONTECOMATLÁN DE LÓPEZ Y FUENTES", "ZOZOCOLCO DE HIDALGO", "AGUA DULCE", 
                        "EL HIGO", "NANCHITAL DE LÁZARO CÁRDENAS DEL RÍO", "TRES VALLES", 
                        "CARLOS A. CARRILLO", "TATAHUICAPAN DE JUÁREZ", "UXPANAPA", "SAN RAFAEL", 
                        "SANTIAGO SOCHIAPAN" };
                    break;
                }
                case 31: // Yucatan
                {
                    cities = new string[] {"Seleccionar",  "ABALÁ", "ACANCEH", "AKIL", "BACA", "BOKOBÁ", "BUCTZOTZ",
                        "CACALCHÉN", "CALOTMUL", "CANSAHCAB", "CANTAMAYEC", "CELESTÚN", "CENOTILLO",
                        "CONKAL", "CUNCUNUL", "CUZAMÁ", "CHACSINKÍN", "CHANKOM", "CHAPAB", "CHEMAX",
                        "CHICXULUB PUEBLO", "CHICHIMILÁ", "CHIKINDZONOT", "CHOCHOLÁ", "CHUMAYEL", "DZÁN",
                        "DZEMUL", "DZIDZANTÚN", "DZILAM DE BRAVO", "DZILAM GONZÁLEZ", "DZITÁS",
                        "DZONCAUICH", "ESPITA", "HALACHÓ", "HOCABÁ", "HOCTÚN", "HOMÚN", "HUHÍ",
                        "HUNUCMÁ", "IXIL", "IZAMAL", "KANASÍN", "KANTUNIL", "KAUA", "KINCHIL", "KOPOMÁ",
                        "MAMA", "MANÍ", "MAXCANÚ", "MAYAPÁN", "MÉRIDA", "MOCOCHÁ", "MOTUL", "MUNA",
                        "MUXUPIP", "OPICHÉN", "OXKUTZCAB", "PANABÁ", "PETO", "PROGRESO", "QUINTANA ROO",
                        "RÍO LAGARTOS", "SACALUM", "SAMAHIL", "SANAHCAT", "SAN FELIPE", "SANTA ELENA",
                        "SEYÉ", "SINANCHÉ", "SOTUTA", "SUCILÁ", "SUDZAL", "SUMA", "TAHDZIÚ", "TAHMEK",
                        "TEABO", "TECOH", "TEKAL DE VENEGAS", "TEKANTÓ", "TEKAX", "TEKIT", "TEKOM",
                        "TELCHAC PUEBLO", "TELCHAC PUERTO", "TEMAX", "TEMOZÓN", "TEPAKÁN", "TETIZ",
                        "TEYA", "TICUL", "TIMUCUY", "TINUM", "TIXCACALCUPUL", "TIXKOKOB", "TIXMEHUAC",
                        "TIXPÉHUAL", "TIZIMÍN", "TUNKÁS", "TZUCACAB", "UAYMA", "UCÚ", "UMÁN", 
                        "VALLADOLID", "XOCCHEL", "YAXCABÁ", "YAXKUKUL", "YOBAÍN"
                    };
                    break;
                }
                case 32: // Zacatecas
                {
                    cities = new string[] {"Seleccionar", "APOZOL", "APULCO", "ATOLINGA", "BENITO JUÁREZ", "CALERA",
                    "CAÑITAS DE FELIPE PESCADOR", "CONCEPCIÓN DEL ORO", "CUAUHTÉMOC", "CHALCHIHUITES",
                    "FRESNILLO", "TRINIDAD GARCÍA DE LA CADENA", "GENARO CODINA",
                    "GENERAL ENRIQUE ESTRADA", "GENERAL FRANCISCO R. MURGUÍA",
                    "EL PLATEADO DE JOAQUÍN AMARO", "GENERAL PÁNFILO NATERA", "GUADALUPE", "HUANUSCO",
                    "JALPA", "JEREZ", "JIMÉNEZ DEL TEUL", "JUAN ALDAMA", "JUCHIPILA", "LORETO",
                    "LUIS MOYA", "MAZAPIL", "MELCHOR OCAMPO", "MEZQUITAL DEL ORO", "MIGUEL AUZA",
                    "MOMAX", "MONTE ESCOBEDO", "MORELOS", "MOYAHUA DE ESTRADA", "NOCHISTLÁN DE MEJÍA",
                    "NORIA DE ÁNGELES", "OJOCALIENTE", "PÁNUCO", "PINOS", "RÍO GRANDE", "SAIN ALTO",
                    "EL SALVADOR", "SOMBRERETE", "SUSTICACÁN", "TABASCO", "TEPECHITLÁN", "TEPETONGO",
                    "TEÚL DE GONZÁLEZ ORTEGA", "TLALTENANGO DE SÁNCHEZ ROMÁN", "VALPARAÍSO",
                    "VETAGRANDE", "VILLA DE COS", "VILLA GARCÍA", "VILLA GONZÁLEZ ORTEGA", 
                    "VILLA HIDALGO", "VILLANUEVA", "ZACATECAS", "TRANCOSO", "SANTA MARÍA DE LA PAZ" };
                    break;
                }
            }

            cbCity.DataSource = cities;
            cbCity.SelectedIndex = 0;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ContractForm contract = FillContract();
            if (!Validate(contract))
            {
                return;
            }

            ContractDTO contractDTO = ContractMapper.CreateDTO(contract);
            contractDAO.Create(contractDTO);

            string action = "[Contratos] Fue creado: " + contract.MeterSerialNumber + ", con ID: " + contract.ContractID;
            new UserRememberDAO().Action(UserCache.id, action);

            FillContractDataGridView();

            ClearForm();
            MessageBox.Show("La operación se realizó exitosamente", "Ambar", MessageBoxButtons.OK);

            DateTime date;
            if (contract.Service == "Domestico")
            {
                date = contract.StartPeriodDate;
                date = (date.Month % 2 == 0) ? date.AddMonths(2) : date.AddMonths(3);
            }
            else if (contract.Service == "Industrial")
            {
                date = contract.StartPeriodDate.AddMonths(1);
            }
            else
            {
                MessageBox.Show("Error inesperado", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string message = string.Format("La carga de consumos inicia el {0}", date.ToString("dd 'de' MMMM 'del' yyyy"));
            MessageBox.Show(message, "Ambar", MessageBoxButtons.OK);
        }

        private ContractForm FillContract()
        {
            ContractForm contract = new ContractForm();
            contract.ContractID = Guid.NewGuid();
            contract.ClientID = Guid.Parse(dtgClients.Rows[dtgPrevIndex].Cells[0].Value.ToString());
            contract.FirstName = dtgClients.Rows[dtgPrevIndex].Cells[3].Value.ToString();
            contract.FatherLastName = dtgClients.Rows[dtgPrevIndex].Cells[4].Value.ToString();
            contract.MotherLastName = dtgClients.Rows[dtgPrevIndex].Cells[5].Value.ToString();
            contract.MeterSerialNumber = StringUtils.GetText(txtMeterSerialNumber.Text);
            contract.ServiceNumber = StringUtils.GetText(txtServiceNumber.Text);
            contract.State = cbState.Text;
            contract.City = cbCity.Text;
            contract.Suburb = StringUtils.GetText(txtSuburb.Text);
            contract.Street = StringUtils.GetText(txtStreet.Text);
            contract.Number = StringUtils.GetText(txtNumber.Text);
            contract.PostalCode = StringUtils.GetText(txtPostalCode.Text);
            contract.Service = cbService.Text;
            contract.StartPeriodDate = dtpStartPeriodDate.Value;
            return contract;
        }

        private bool Validate(ContractForm contract)
        {
            if (contract.FirstName == string.Empty || contract.FatherLastName == string.Empty ||
                contract.MotherLastName == string.Empty || contract.MeterSerialNumber == string.Empty || 
                contract.Service == string.Empty || contract.Service == "Seleccionar" || contract.State == string.Empty || 
                contract.State == "Seleccionar" || contract.City == string.Empty || contract.City == "Seleccionar" ||
                contract.Suburb == string.Empty || contract.Street == string.Empty || contract.Number == string.Empty ||
                contract.PostalCode == string.Empty || contract.FirstName == string.Empty ||
                contract.FatherLastName == string.Empty || contract.MotherLastName == string.Empty)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            long serviceNumber;
            if (!long.TryParse(contract.ServiceNumber, out serviceNumber) || !RegexUtils.OnlyNumbers(contract.ServiceNumber))
            {
                MessageBox.Show("Número de servicio no valido", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (serviceNumber == 0)
            {
                MessageBox.Show("El número de servicio no puede ser 0", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (contractDAO.ContractExists(contract.MeterSerialNumber, serviceNumber))
            {
                MessageBox.Show("El número de medidor o número de servicio ya existe", "Ambar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtMeterSerialNumber.Clear();
            txtServiceNumber.Clear();
            cbService.SelectedIndex = 0;
            cbState.SelectedIndex = 0;
            cbCity.SelectedIndex = 0;
            txtSuburb.Clear();
            txtStreet.Clear();
            txtNumber.Clear();
            txtPostalCode.Clear();
            dtpStartPeriodDate.Value = dtpStartPeriodDate.MinDate;
            txtClient.Clear();
            dtgContracts.DataSource = new List<ContractDTO>();
            btnAccept.Enabled = false;
            dtgPrevIndex = -1;
        }

        private void FillContractDataGridView()
        {
            List<ContractDTO> contracts = contractDAO.ReadClientContracts(Guid.Parse(dtgClients.Rows[dtgPrevIndex].Cells[0].Value.ToString()));
            List<ContractDTG> dtgContractsList = new List<ContractDTG>();
            foreach (var contract in contracts)
            {
                dtgContractsList.Add(new ContractDTG(contract));
            }
            dtgContracts.DataSource = dtgContractsList;
        }

        private void dtgClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (dtgPrevIndex == index || index == -1)
            {
                ClearForm();
            }
            else
            {
                dtgPrevIndex = index;
                txtClient.Text = dtgClients.Rows[index].Cells[1].Value.ToString();
                FillContractDataGridView();
                btnAccept.Enabled = true;
            }
        }

        // Si no se ha cargado ningun recibo, el programa te deja empezar un par de meses antes para empezar los
        // contratos, ya que de no ser asi la primera factura no podria tener ningun contrato
        // despues del primer recibo empezara a respetar la fecha y no te dejara hacer ningun contrato
        // en fechas pasadas
        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dateDAO.GetInitial())
            {
                switch (cbService.SelectedIndex)
                {
                    case 0:
                    {
                        dtpStartPeriodDate.MinDate = dateDAO.GetDate();
                        break;
                    }
                    case 1:
                    {
                        dtpStartPeriodDate.MinDate = dateDAO.GetDate().AddMonths(-2);
                        break;
                    }
                    case 2:
                    {
                        dtpStartPeriodDate.MinDate = dateDAO.GetDate().AddMonths(-1);
                        break;
                    }
                }
            }
        }

        private void FillClientDataGridView()
        {
            ClientDAO clientDAO = new ClientDAO();
            List<ClientDTO> clients = clientDAO.ReadAll();
            List<ClientDTG> dtgClientsList = new List<ClientDTG>();
            foreach (var client in clients)
            {
                dtgClientsList.Add(new ClientDTG(client));
            }
            dtgClients.DataSource = dtgClientsList;
            dtgClients.Columns["Emails"].Visible = false;
        }
    }
}
