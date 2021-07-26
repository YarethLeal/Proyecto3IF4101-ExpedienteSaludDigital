package ucr.ac.cr.proyecto3_b87107_b84211.modelos;

public class Citas {
    private int id;
    private int cedula;
    private String centro_salud;
    private String fecha;
    private String especialidad;
    private String descripción;
    private String codigo ;

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

    public String getCentro_salud() {
        return centro_salud;
    }

    public void setCentro_salud(String centro_salud) {
        this.centro_salud = centro_salud;
    }

    public String getFecha() {
        return fecha;
    }

    public void setFecha(String fecha) {
        this.fecha = fecha;
    }

    public String getEspecialidad() {
        return especialidad;
    }

    public void setEspecialidad(String especialidad) {
        this.especialidad = especialidad;
    }

    public String getDescripción() {
        return descripción;
    }

    public void setDescripción(String descripción) {
        this.descripción = descripción;
    }

    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }
}
