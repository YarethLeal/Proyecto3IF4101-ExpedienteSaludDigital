package ucr.ac.cr.proyecto3_b87107_b84211.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import org.jetbrains.annotations.NotNull;

import java.util.ArrayList;
import java.util.List;

import ucr.ac.cr.proyecto3_b87107_b84211.R;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Alergias;

public class ListaAlergiasAdapter extends RecyclerView.Adapter<ItemAlergiaViewHolder> {
    private List<Alergias> listaAlergias;
    private Context context;
    private Boolean contedorMasDetalles=false;

    public ListaAlergiasAdapter(List<Alergias> listaAlergias,Context context) {
        this.listaAlergias = listaAlergias;
        this.context =context;
    }

    @NonNull
    @Override
    public ItemAlergiaViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View itemLista = inflater.inflate(R.layout.item_alergia, parent, false);
        ItemAlergiaViewHolder viewHolder = new ItemAlergiaViewHolder(itemLista);

        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull ItemAlergiaViewHolder holder, int position) {
        final Alergias alergiaActual = listaAlergias.get(position);
        holder.vacuna.setText(alergiaActual.getAlergia());
        holder.fecha.setText(alergiaActual.getFecha());
        holder.medicamentos.setText(alergiaActual.getMedicamentos());
        holder.descripcion.setText(alergiaActual.getDescripcion());

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
        return listaAlergias.size();
    }
}
