using SnowKore.Services;
using System.Collections.Generic;

public class SaveProgressServiceData : NewServiceData
{
    private int usuario;
    private int estado;
    private int puntos;
    private string incidencias;
    private float estres;
    private float enfoque;
    private float relajacion;
    private int bonus;
    private Item Item;
    public SaveProgressServiceData( int usuario, int estado, int puntos, string incidencias, float estres, float enfoque, float relajacion, int bonus)
    {
        this.usuario = usuario;
        this.estado = estado;
        this.puntos = puntos;
        this.incidencias = incidencias;
        this.estres = estres;
        this.enfoque = enfoque;
        this.relajacion = relajacion;
        this.bonus = bonus;
    }
    //public SaveProgressServiceData(int usuario, Item item)
    //{
    //    this.usuario = usuario;
    //    this.Item = item;
    //}

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("usuario", usuario);
            body.Add("estado", estado);
            body.Add("puntos", puntos);
            body.Add("incidencias", incidencias);
            body.Add("estres", estres);
            body.Add("enfoque", enfoque);
            body.Add("relajacion", relajacion);
            body.Add("bonus", bonus);
            return body;
        }
    }

    protected override string ServiceURL => "crearItem";

    protected override Dictionary<string, object> Params
    {
        get
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            return parameters;
        }
    }

    protected override Dictionary<string, string> Headers
    {
        get
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            return headers;
        }
    }

    protected override ServiceType ServiceType => ServiceType.POST;
}
