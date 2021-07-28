package ucr.ac.cr.proyecto3_b87107_b84211.modelos;

public class Usuario {
    private Integer cedula;
    private String contrasena;
    private String nombre;
    private Integer edad;
    private String tpSangre;
    private String estado_civil;
    private Integer telefono;
    private String domicilio;

    public Usuario(String estado_civil, Integer telefono, String domicilio) {
        this.estado_civil = estado_civil;
        this.telefono = telefono;
        this.domicilio = domicilio;
    }

    public Usuario(Integer cedula, String contrasena) {
        this.cedula = cedula;
        this.contrasena = contrasena;
    }

    public int getCedula() {
        return cedula;
    }

    public void setCedula(int cedula) {
        this.cedula = cedula;
    }

    public String getContrasena() {
        return contrasena;
    }

    public void setContrasena(String contrasena) {
        this.contrasena = contrasena;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getEdad() {
        return edad;
    }

    public void setEdad(int edad) {
        this.edad = edad;
    }

    public String getTpSangre() {
        return tpSangre;
    }

    public void setTpSangre(String tpSangre) {
        this.tpSangre = tpSangre;
    }

    public String getEstado_civil() {
        return estado_civil;
    }

    public void setEstado_civil(String estado_civil) {
        this.estado_civil = estado_civil;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }

    public String getDomicilio() {
        return domicilio;
    }

    public void setDomicilio(String domicilio) {
        this.domicilio = domicilio;
    }
}
