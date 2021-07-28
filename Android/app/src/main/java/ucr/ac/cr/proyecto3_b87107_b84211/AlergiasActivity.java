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
import ucr.ac.cr.proyecto3_b87107_b84211.adapters.ListaAlergiasAdapter;
import ucr.ac.cr.proyecto3_b87107_b84211.interfaces.HistorialMedicoApi;
import ucr.ac.cr.proyecto3_b87107_b84211.interfaces.UsuarioAPI;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Alergias;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Vacunas;

public class AlergiasActivity extends AppCompatActivity {
    TextView cedulaId;
    ImageButton btnSalir;

    private RecyclerView listaAlergiasRecycler;
    private List<Alergias> alergias = new ArrayList<>();

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_alergias);

        Bundle bundle = getIntent().getExtras();
        String cedulaUser = bundle.getString("userId");
        btnSalir=findViewById(R.id.exitBtn);
        cedulaId=findViewById(R.id.txtCedula);
        cedulaId.setText(cedulaUser);
        listaAlergiasRecycler = findViewById(R.id.AlergiasRecycle);
        listaAlergiasRecycler.setLayoutManager(new LinearLayoutManager(AlergiasActivity.this));
        obtenerAlergias(cedulaUser);

        btnSalir.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intentLogin = new Intent(getApplicationContext(), LoginActivity.class);
                startActivity(intentLogin);
            }
        });

    }

    private void obtenerAlergias(String cedula) {

        Retrofit retrofit=new Retrofit.Builder().baseUrl("https://api-b87107-b84211.azurewebsites.net/")
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        HistorialMedicoApi historialAPI=retrofit.create(HistorialMedicoApi.class);
        Call<List<Alergias>> call=historialAPI.alergias(cedula);
        call.enqueue(new Callback<List<Alergias>>() {

            @Override
            public void onResponse(Call<List<Alergias>> call, Response<List<Alergias>> response) {
                try {
                    if(response.isSuccessful()){
                        alergias=response.body();
                        ListaAlergiasAdapter adapter = new ListaAlergiasAdapter(alergias,AlergiasActivity.this);
                        listaAlergiasRecycler.setAdapter(adapter);

                    }
                }catch (Exception ex){
                    Toast.makeText(AlergiasActivity.this,ex.getMessage(),Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<Alergias>> call, Throwable t) {
                Toast.makeText(AlergiasActivity.this,"Error de conexion",Toast.LENGTH_SHORT).show();
            }
        });
      //  Toast.makeText(AlergiasActivity.this,alergias.get(1).getAlergia(),Toast.LENGTH_SHORT).show();
       // alergias.add(new Alergias("Asma","12-07-2021"));
        //return alergias;
    }
}
