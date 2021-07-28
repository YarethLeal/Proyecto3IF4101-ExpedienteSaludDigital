package ucr.ac.cr.proyecto3_b87107_b84211;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import ucr.ac.cr.proyecto3_b87107_b84211.adapters.ListaVacunasAdapter;
import ucr.ac.cr.proyecto3_b87107_b84211.interfaces.HistorialMedicoApi;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Vacunas;

public class VacunasActivity extends AppCompatActivity {
    TextView cedulaId;
    ImageButton btnSalir;

    private RecyclerView listaVacunasRecycler;
    private List<Vacunas> vacunas = new ArrayList<>();
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_vacunas);
        Bundle bundle = getIntent().getExtras();
        String cedulaUser = bundle.getString("userId");
        btnSalir=findViewById(R.id.exitBtn);
        cedulaId=findViewById(R.id.txtCedula);
        cedulaId.setText(cedulaUser);
        listaVacunasRecycler = findViewById(R.id.VacunasRecycle);
        listaVacunasRecycler.setLayoutManager(new LinearLayoutManager(VacunasActivity.this));
        obtenerVacunas(cedulaUser);

        btnSalir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentLogin = new Intent(getApplicationContext(), LoginActivity.class);
                startActivity(intentLogin);
            }
        });
    }
    private void obtenerVacunas(String cedula) {

        Retrofit retrofit=new Retrofit.Builder().baseUrl("https://api-b87107-b84211.azurewebsites.net/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        HistorialMedicoApi historialAPI=retrofit.create(HistorialMedicoApi.class);
        Call<List<Vacunas>> call=historialAPI.vacunas(cedula);
        call.enqueue(new Callback<List<Vacunas>>() {

            @Override
            public void onResponse(Call<List<Vacunas>> call, Response<List<Vacunas>> response) {
                try {
                    if(response.isSuccessful()){
                        vacunas=response.body();
                        ListaVacunasAdapter adapter = new ListaVacunasAdapter(vacunas,VacunasActivity.this);
                        listaVacunasRecycler.setAdapter(adapter);

                    }
                }catch (Exception ex){
                    Toast.makeText(VacunasActivity.this,ex.getMessage(),Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<Vacunas>> call, Throwable t) {
                Toast.makeText(VacunasActivity.this,"Error de conexion",Toast.LENGTH_SHORT).show();
            }
        });
    }
}
