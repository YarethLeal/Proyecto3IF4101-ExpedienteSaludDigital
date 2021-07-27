package ucr.ac.cr.proyecto3_b87107_b84211.interfaces;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Alergias;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Citas;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Vacunas;

public interface HistorialMedicoApi {

        @GET("Alergias/{cedula}")
        Call<List<Alergias>> alergias(@Path("cedula") String cedula);

        @GET("Citas/{cedula}")
        public Call<List<Citas>> citas(@Path("cedula") String cedula);

        @GET("Vacunas/{cedula}")
        public Call<List<Vacunas>> vacunas(@Path("cedula") String cedula);

}
