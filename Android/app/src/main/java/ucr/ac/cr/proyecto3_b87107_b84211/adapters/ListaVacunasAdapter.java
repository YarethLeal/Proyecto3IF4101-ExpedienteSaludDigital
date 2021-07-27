package ucr.ac.cr.proyecto3_b87107_b84211.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import ucr.ac.cr.proyecto3_b87107_b84211.R;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Alergias;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Vacunas;

public class ListaVacunasAdapter extends RecyclerView.Adapter<ItemVacunaViewHolder>{
    private List<Vacunas> listaVacunas;
    private Context context;
    private Boolean contedorMasDetalles=false;

    public ListaVacunasAdapter(List<Vacunas> listaVacunas,Context context) {
        this.listaVacunas = listaVacunas;
        this.context =context;
    }

    @NonNull
    @Override
    public ItemVacunaViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View itemLista = inflater.inflate(R.layout.item_vacuna, parent, false);
        ItemVacunaViewHolder viewHolder = new ItemVacunaViewHolder(itemLista);

        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull ItemVacunaViewHolder holder, int position) {
        final Vacunas vacunaActual = listaVacunas.get(position);
        holder.vacuna.setText(vacunaActual.getVacuna());
        holder.fechaApli.setText(vacunaActual.getFecha_aplicacion());
        holder.fechaProx.setText(vacunaActual.getFecha_prox_dos());
        holder.descripcion.setText(vacunaActual.getDescripcion());

        holder.verDetalles.setOnClickListener(view->{
            if (contedorMasDetalles==false)
            {
                contedorMasDetalles=true;
                holder.layoutDetalles.setVisibility(View.VISIBLE);
                holder.verDetalles.setText(context.getString(R.string.ocultar_detalles));
            }else
            {
                contedorMasDetalles=false;
                holder.layoutDetalles.setVisibility(View.GONE);
                holder.verDetalles.setText(context.getString(R.string.detalles));

            }
        });

    }

    @Override
    public int getItemCount() {
        return listaVacunas.size();
    }
}
