package ucr.ac.cr.proyecto3_b87107_b84211.modelos;

import com.google.gson.annotations.SerializedName;

public class Alergias {
    @SerializedName("id")
    private int id;
    @SerializedName("cedula")
    private int cedula;
    @SerializedName("alergia")
    private String alergia;
    @SerializedName("fecha")
    private String fecha;
    @SerializedName("medicamentos")
    private String medicamentos;
    @SerializedName("descripcion")
    private String descripcion;

    public Alergias(String alergia,String fecha) {
        this.alergia = alergia;
        this.fecha = fecha;
    }

    public Alergias(int id, int cedula, String alergia, String fecha, String medicamentos, String descripcion) {
        this.id = id;
        this.cedula = cedula;
        this.alergia = alergia;
        this.fecha = fecha;
        this.medicamentos = medicamentos;
        this.descripcion = descripcion;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getCedula() {
        return cedula;
    }

    public void setCedula(int cedula) {
        this.cedula = cedula;
    }

    public String getAlergia() {
        return alergia;
    }

    public void setAlergia(String alergia) {
        this.alergia = alergia;
    }

    public String getFecha() {
        return fecha;
    }

    public void setFecha(String fecha) {
        this.fecha = fecha;
    }

    public String getMedicamentos() {
        return medicamentos;
    }

    public void setMedicamentos(String medicamentos) {
        this.medicamentos = medicamentos;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
}
