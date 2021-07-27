package ucr.ac.cr.proyecto3_b87107_b84211.interfaces;

import com.google.gson.Gson;

import java.util.HashMap;

import retrofit2.Call;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.Body;
import retrofit2.http.Field;
import retrofit2.http.FieldMap;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.GET;
import retrofit2.http.Headers;
import retrofit2.http.POST;
import retrofit2.http.Path;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Usuario;

public interface UsuarioAPI {
    @GET("Usuario/{cedula}/{contrasena}")
    public Call<Integer> find(@Path("cedula") String cedula,@Path("contrasena") String contrasena);

    @GET("Usuario/{cedula}/{contrasena}/{num}")
    public Call<String> register(@Path("cedula") String cedula,@Path("contrasena") String contrasena,@Path("num") String num);
}
