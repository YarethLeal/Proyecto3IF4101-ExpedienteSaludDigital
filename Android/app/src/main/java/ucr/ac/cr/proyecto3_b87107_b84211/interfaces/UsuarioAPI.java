package ucr.ac.cr.proyecto3_b87107_b84211.interfaces;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Usuario;

public interface UsuarioAPI {
    @GET("Usuario/{cedula}/{contrasena}")
    public Call<Integer> find(@Path("cedula") String cedula,@Path("contrasena") String contrasena);
}
