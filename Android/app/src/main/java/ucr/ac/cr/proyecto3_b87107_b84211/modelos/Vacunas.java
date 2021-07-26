package ucr.ac.cr.proyecto3_b87107_b84211.modelos;

public class Vacunas {
    private int id;
    private int cedula;
    private String vacuna;
    private String descripcion;
    private String  fecha_aplicacion;
    private String fecha_prox_dos;

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

    public String getVacuna() {
        return vacuna;
    }

    public void setVacuna(String vacuna) {
        this.vacuna = vacuna;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public String getFecha_aplicacion() {
        return fecha_aplicacion;
    }

    public void setFecha_aplicacion(String fecha_aplicacion) {
        this.fecha_aplicacion = fecha_aplicacion;
    }

    public String getFecha_prox_dos() {
        return fecha_prox_dos;
    }

    public void setFecha_prox_dos(String fecha_prox_dos) {
        this.fecha_prox_dos = fecha_prox_dos;
    }
}
