﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaSacMvcVer2.Infraestructura.WS_SAFI {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfFichaContratoSAFI", Namespace="http://tempuri.org/", ItemName="fichaContratoSAFI")]
    [System.SerializableAttribute()]
    public class ArrayOfFichaContratoSAFI : System.Collections.Generic.List<SistemaSacMvcVer2.Infraestructura.WS_SAFI.fichaContratoSAFI> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="fichaContratoSAFI", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class fichaContratoSAFI : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CODIGOCONTRATOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NOMBRECONTRATOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TIPOCONTRATOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RUTINSPECTORFISCALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NOMBREINSPECTORFISCALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RUTCONTRATISTAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NOMBRECONTRATISTAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NUMERORESOLUCIONORIGINALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FECHARESOLUCIONORIGINALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FECHATRAMITERESOLUCIONORIGINALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MODALIDADCONTRATACIONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MODALIDADREAJUSTEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRESUPUESTOOFICIALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MONTOINICIALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MONTOVIGENTEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PLAZOVIGENTEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FECHATERMINOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FECHAINICIOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MONTOMODIFICACIONENTRAMITEField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PLAZOORIGINALField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CENTROGESTIONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SUBTIPOGASTO2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SERVICIOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CLASIFICACIONINVERSIONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string REGIONGEOGRAFICAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SUBCENTROGESTIONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FECHAPUBLICACIONLICITACIONField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FECHAAPERTURATECNICAField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FECHAAPERTURAECONOMICAField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string CODIGOCONTRATO {
            get {
                return this.CODIGOCONTRATOField;
            }
            set {
                if ((object.ReferenceEquals(this.CODIGOCONTRATOField, value) != true)) {
                    this.CODIGOCONTRATOField = value;
                    this.RaisePropertyChanged("CODIGOCONTRATO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NOMBRECONTRATO {
            get {
                return this.NOMBRECONTRATOField;
            }
            set {
                if ((object.ReferenceEquals(this.NOMBRECONTRATOField, value) != true)) {
                    this.NOMBRECONTRATOField = value;
                    this.RaisePropertyChanged("NOMBRECONTRATO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TIPOCONTRATO {
            get {
                return this.TIPOCONTRATOField;
            }
            set {
                if ((object.ReferenceEquals(this.TIPOCONTRATOField, value) != true)) {
                    this.TIPOCONTRATOField = value;
                    this.RaisePropertyChanged("TIPOCONTRATO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string RUTINSPECTORFISCAL {
            get {
                return this.RUTINSPECTORFISCALField;
            }
            set {
                if ((object.ReferenceEquals(this.RUTINSPECTORFISCALField, value) != true)) {
                    this.RUTINSPECTORFISCALField = value;
                    this.RaisePropertyChanged("RUTINSPECTORFISCAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string NOMBREINSPECTORFISCAL {
            get {
                return this.NOMBREINSPECTORFISCALField;
            }
            set {
                if ((object.ReferenceEquals(this.NOMBREINSPECTORFISCALField, value) != true)) {
                    this.NOMBREINSPECTORFISCALField = value;
                    this.RaisePropertyChanged("NOMBREINSPECTORFISCAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string RUTCONTRATISTA {
            get {
                return this.RUTCONTRATISTAField;
            }
            set {
                if ((object.ReferenceEquals(this.RUTCONTRATISTAField, value) != true)) {
                    this.RUTCONTRATISTAField = value;
                    this.RaisePropertyChanged("RUTCONTRATISTA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string NOMBRECONTRATISTA {
            get {
                return this.NOMBRECONTRATISTAField;
            }
            set {
                if ((object.ReferenceEquals(this.NOMBRECONTRATISTAField, value) != true)) {
                    this.NOMBRECONTRATISTAField = value;
                    this.RaisePropertyChanged("NOMBRECONTRATISTA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string NUMERORESOLUCIONORIGINAL {
            get {
                return this.NUMERORESOLUCIONORIGINALField;
            }
            set {
                if ((object.ReferenceEquals(this.NUMERORESOLUCIONORIGINALField, value) != true)) {
                    this.NUMERORESOLUCIONORIGINALField = value;
                    this.RaisePropertyChanged("NUMERORESOLUCIONORIGINAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string FECHARESOLUCIONORIGINAL {
            get {
                return this.FECHARESOLUCIONORIGINALField;
            }
            set {
                if ((object.ReferenceEquals(this.FECHARESOLUCIONORIGINALField, value) != true)) {
                    this.FECHARESOLUCIONORIGINALField = value;
                    this.RaisePropertyChanged("FECHARESOLUCIONORIGINAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string FECHATRAMITERESOLUCIONORIGINAL {
            get {
                return this.FECHATRAMITERESOLUCIONORIGINALField;
            }
            set {
                if ((object.ReferenceEquals(this.FECHATRAMITERESOLUCIONORIGINALField, value) != true)) {
                    this.FECHATRAMITERESOLUCIONORIGINALField = value;
                    this.RaisePropertyChanged("FECHATRAMITERESOLUCIONORIGINAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string MODALIDADCONTRATACION {
            get {
                return this.MODALIDADCONTRATACIONField;
            }
            set {
                if ((object.ReferenceEquals(this.MODALIDADCONTRATACIONField, value) != true)) {
                    this.MODALIDADCONTRATACIONField = value;
                    this.RaisePropertyChanged("MODALIDADCONTRATACION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string MODALIDADREAJUSTE {
            get {
                return this.MODALIDADREAJUSTEField;
            }
            set {
                if ((object.ReferenceEquals(this.MODALIDADREAJUSTEField, value) != true)) {
                    this.MODALIDADREAJUSTEField = value;
                    this.RaisePropertyChanged("MODALIDADREAJUSTE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string PRESUPUESTOOFICIAL {
            get {
                return this.PRESUPUESTOOFICIALField;
            }
            set {
                if ((object.ReferenceEquals(this.PRESUPUESTOOFICIALField, value) != true)) {
                    this.PRESUPUESTOOFICIALField = value;
                    this.RaisePropertyChanged("PRESUPUESTOOFICIAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string MONTOINICIAL {
            get {
                return this.MONTOINICIALField;
            }
            set {
                if ((object.ReferenceEquals(this.MONTOINICIALField, value) != true)) {
                    this.MONTOINICIALField = value;
                    this.RaisePropertyChanged("MONTOINICIAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string MONTOVIGENTE {
            get {
                return this.MONTOVIGENTEField;
            }
            set {
                if ((object.ReferenceEquals(this.MONTOVIGENTEField, value) != true)) {
                    this.MONTOVIGENTEField = value;
                    this.RaisePropertyChanged("MONTOVIGENTE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string PLAZOVIGENTE {
            get {
                return this.PLAZOVIGENTEField;
            }
            set {
                if ((object.ReferenceEquals(this.PLAZOVIGENTEField, value) != true)) {
                    this.PLAZOVIGENTEField = value;
                    this.RaisePropertyChanged("PLAZOVIGENTE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string FECHATERMINO {
            get {
                return this.FECHATERMINOField;
            }
            set {
                if ((object.ReferenceEquals(this.FECHATERMINOField, value) != true)) {
                    this.FECHATERMINOField = value;
                    this.RaisePropertyChanged("FECHATERMINO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string FECHAINICIO {
            get {
                return this.FECHAINICIOField;
            }
            set {
                if ((object.ReferenceEquals(this.FECHAINICIOField, value) != true)) {
                    this.FECHAINICIOField = value;
                    this.RaisePropertyChanged("FECHAINICIO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string MONTOMODIFICACIONENTRAMITE {
            get {
                return this.MONTOMODIFICACIONENTRAMITEField;
            }
            set {
                if ((object.ReferenceEquals(this.MONTOMODIFICACIONENTRAMITEField, value) != true)) {
                    this.MONTOMODIFICACIONENTRAMITEField = value;
                    this.RaisePropertyChanged("MONTOMODIFICACIONENTRAMITE");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string PLAZOORIGINAL {
            get {
                return this.PLAZOORIGINALField;
            }
            set {
                if ((object.ReferenceEquals(this.PLAZOORIGINALField, value) != true)) {
                    this.PLAZOORIGINALField = value;
                    this.RaisePropertyChanged("PLAZOORIGINAL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string CENTROGESTION {
            get {
                return this.CENTROGESTIONField;
            }
            set {
                if ((object.ReferenceEquals(this.CENTROGESTIONField, value) != true)) {
                    this.CENTROGESTIONField = value;
                    this.RaisePropertyChanged("CENTROGESTION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=21)]
        public string SUBTIPOGASTO2 {
            get {
                return this.SUBTIPOGASTO2Field;
            }
            set {
                if ((object.ReferenceEquals(this.SUBTIPOGASTO2Field, value) != true)) {
                    this.SUBTIPOGASTO2Field = value;
                    this.RaisePropertyChanged("SUBTIPOGASTO2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=22)]
        public string SERVICIO {
            get {
                return this.SERVICIOField;
            }
            set {
                if ((object.ReferenceEquals(this.SERVICIOField, value) != true)) {
                    this.SERVICIOField = value;
                    this.RaisePropertyChanged("SERVICIO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=23)]
        public string CLASIFICACIONINVERSION {
            get {
                return this.CLASIFICACIONINVERSIONField;
            }
            set {
                if ((object.ReferenceEquals(this.CLASIFICACIONINVERSIONField, value) != true)) {
                    this.CLASIFICACIONINVERSIONField = value;
                    this.RaisePropertyChanged("CLASIFICACIONINVERSION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=24)]
        public string REGIONGEOGRAFICA {
            get {
                return this.REGIONGEOGRAFICAField;
            }
            set {
                if ((object.ReferenceEquals(this.REGIONGEOGRAFICAField, value) != true)) {
                    this.REGIONGEOGRAFICAField = value;
                    this.RaisePropertyChanged("REGIONGEOGRAFICA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=25)]
        public string SUBCENTROGESTION {
            get {
                return this.SUBCENTROGESTIONField;
            }
            set {
                if ((object.ReferenceEquals(this.SUBCENTROGESTIONField, value) != true)) {
                    this.SUBCENTROGESTIONField = value;
                    this.RaisePropertyChanged("SUBCENTROGESTION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=26)]
        public string FECHAPUBLICACIONLICITACION {
            get {
                return this.FECHAPUBLICACIONLICITACIONField;
            }
            set {
                if ((object.ReferenceEquals(this.FECHAPUBLICACIONLICITACIONField, value) != true)) {
                    this.FECHAPUBLICACIONLICITACIONField = value;
                    this.RaisePropertyChanged("FECHAPUBLICACIONLICITACION");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=27)]
        public string FECHAAPERTURATECNICA {
            get {
                return this.FECHAAPERTURATECNICAField;
            }
            set {
                if ((object.ReferenceEquals(this.FECHAAPERTURATECNICAField, value) != true)) {
                    this.FECHAAPERTURATECNICAField = value;
                    this.RaisePropertyChanged("FECHAAPERTURATECNICA");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=28)]
        public string FECHAAPERTURAECONOMICA {
            get {
                return this.FECHAAPERTURAECONOMICAField;
            }
            set {
                if ((object.ReferenceEquals(this.FECHAAPERTURAECONOMICAField, value) != true)) {
                    this.FECHAAPERTURAECONOMICAField = value;
                    this.RaisePropertyChanged("FECHAAPERTURAECONOMICA");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WS_SAFI.ServicioInformacionFichaContratosSAFISoap")]
    public interface ServicioInformacionFichaContratosSAFISoap {
        
        // CODEGEN: Generating message contract since element name InfoContratosSAFIResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InfoContratosSAFI", ReplyAction="*")]
        SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIResponse InfoContratosSAFI(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InfoContratosSAFI", ReplyAction="*")]
        System.Threading.Tasks.Task<SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIResponse> InfoContratosSAFIAsync(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequest request);
        
        // CODEGEN: Generating message contract since element name InfoContratosSAFIXRutResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InfoContratosSAFIXRut", ReplyAction="*")]
        SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutResponse InfoContratosSAFIXRut(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InfoContratosSAFIXRut", ReplyAction="*")]
        System.Threading.Tasks.Task<SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutResponse> InfoContratosSAFIXRutAsync(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InfoContratosSAFIRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InfoContratosSAFI", Namespace="http://tempuri.org/", Order=0)]
        public SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequestBody Body;
        
        public InfoContratosSAFIRequest() {
        }
        
        public InfoContratosSAFIRequest(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InfoContratosSAFIRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int CodigoSAFI;
        
        public InfoContratosSAFIRequestBody() {
        }
        
        public InfoContratosSAFIRequestBody(int CodigoSAFI) {
            this.CodigoSAFI = CodigoSAFI;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InfoContratosSAFIResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InfoContratosSAFIResponse", Namespace="http://tempuri.org/", Order=0)]
        public SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIResponseBody Body;
        
        public InfoContratosSAFIResponse() {
        }
        
        public InfoContratosSAFIResponse(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InfoContratosSAFIResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SistemaSacMvcVer2.Infraestructura.WS_SAFI.ArrayOfFichaContratoSAFI InfoContratosSAFIResult;
        
        public InfoContratosSAFIResponseBody() {
        }
        
        public InfoContratosSAFIResponseBody(SistemaSacMvcVer2.Infraestructura.WS_SAFI.ArrayOfFichaContratoSAFI InfoContratosSAFIResult) {
            this.InfoContratosSAFIResult = InfoContratosSAFIResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InfoContratosSAFIXRutRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InfoContratosSAFIXRut", Namespace="http://tempuri.org/", Order=0)]
        public SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequestBody Body;
        
        public InfoContratosSAFIXRutRequest() {
        }
        
        public InfoContratosSAFIXRutRequest(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InfoContratosSAFIXRutRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int Rut;
        
        public InfoContratosSAFIXRutRequestBody() {
        }
        
        public InfoContratosSAFIXRutRequestBody(int Rut) {
            this.Rut = Rut;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class InfoContratosSAFIXRutResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="InfoContratosSAFIXRutResponse", Namespace="http://tempuri.org/", Order=0)]
        public SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutResponseBody Body;
        
        public InfoContratosSAFIXRutResponse() {
        }
        
        public InfoContratosSAFIXRutResponse(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class InfoContratosSAFIXRutResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public SistemaSacMvcVer2.Infraestructura.WS_SAFI.ArrayOfFichaContratoSAFI InfoContratosSAFIXRutResult;
        
        public InfoContratosSAFIXRutResponseBody() {
        }
        
        public InfoContratosSAFIXRutResponseBody(SistemaSacMvcVer2.Infraestructura.WS_SAFI.ArrayOfFichaContratoSAFI InfoContratosSAFIXRutResult) {
            this.InfoContratosSAFIXRutResult = InfoContratosSAFIXRutResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServicioInformacionFichaContratosSAFISoapChannel : SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioInformacionFichaContratosSAFISoapClient : System.ServiceModel.ClientBase<SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap>, SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap {
        
        public ServicioInformacionFichaContratosSAFISoapClient() {
        }
        
        public ServicioInformacionFichaContratosSAFISoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioInformacionFichaContratosSAFISoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioInformacionFichaContratosSAFISoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioInformacionFichaContratosSAFISoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIResponse SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap.InfoContratosSAFI(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequest request) {
            return base.Channel.InfoContratosSAFI(request);
        }
        
        public SistemaSacMvcVer2.Infraestructura.WS_SAFI.ArrayOfFichaContratoSAFI InfoContratosSAFI(int CodigoSAFI) {
            SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequest inValue = new SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequest();
            inValue.Body = new SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequestBody();
            inValue.Body.CodigoSAFI = CodigoSAFI;
            SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIResponse retVal = ((SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap)(this)).InfoContratosSAFI(inValue);
            return retVal.Body.InfoContratosSAFIResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIResponse> SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap.InfoContratosSAFIAsync(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequest request) {
            return base.Channel.InfoContratosSAFIAsync(request);
        }
        
        public System.Threading.Tasks.Task<SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIResponse> InfoContratosSAFIAsync(int CodigoSAFI) {
            SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequest inValue = new SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequest();
            inValue.Body = new SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIRequestBody();
            inValue.Body.CodigoSAFI = CodigoSAFI;
            return ((SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap)(this)).InfoContratosSAFIAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutResponse SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap.InfoContratosSAFIXRut(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequest request) {
            return base.Channel.InfoContratosSAFIXRut(request);
        }
        
        public SistemaSacMvcVer2.Infraestructura.WS_SAFI.ArrayOfFichaContratoSAFI InfoContratosSAFIXRut(int Rut) {
            SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequest inValue = new SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequest();
            inValue.Body = new SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequestBody();
            inValue.Body.Rut = Rut;
            SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutResponse retVal = ((SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap)(this)).InfoContratosSAFIXRut(inValue);
            return retVal.Body.InfoContratosSAFIXRutResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutResponse> SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap.InfoContratosSAFIXRutAsync(SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequest request) {
            return base.Channel.InfoContratosSAFIXRutAsync(request);
        }
        
        public System.Threading.Tasks.Task<SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutResponse> InfoContratosSAFIXRutAsync(int Rut) {
            SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequest inValue = new SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequest();
            inValue.Body = new SistemaSacMvcVer2.Infraestructura.WS_SAFI.InfoContratosSAFIXRutRequestBody();
            inValue.Body.Rut = Rut;
            return ((SistemaSacMvcVer2.Infraestructura.WS_SAFI.ServicioInformacionFichaContratosSAFISoap)(this)).InfoContratosSAFIXRutAsync(inValue);
        }
    }
}
